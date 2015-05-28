namespace FsxCommunicator.Infrastructure
{
    using System;
    using FsxWebApi.Infrastructure.FsxConfig.Enums;
    using FsxConfig;
    using Interfaces;
    using Model;
    using Microsoft.FlightSimulator.SimConnect;

    public class FsxCommunicator
    {
        private readonly ILogger _logger;
        // SimConnect object
        private SimConnect _simConnect;
        private bool _receivedMessage = false;
        private PlaneData _planeData;

        public FsxCommunicator(ILogger logger)
        {
            _logger = logger;
        }

        public PlaneData GetPlaneData()
        {
            if (!ConnectToFsxIfNecessary())
            {
                return null;
            }

            _simConnect.RequestDataOnSimObjectType(DataRequest.FromBrowser, Definition.Plane, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
            
            // ReceiveMessage must be called to trigger the events. 
            do
            {
                try
                {
                    _simConnect.ReceiveMessage();
                }
                catch (Exception)
                {
                    return null;
                }
            } while (!_receivedMessage);

            _receivedMessage = false;

            return _planeData;
        }

        public void Fsx_ReceiveDataEventHandler(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE fsxData)
        {

            switch ((DataRequest)fsxData.dwRequestID)
            {
                case DataRequest.FromBrowser:
                    var userPlaneData = (PlaneDataStruct)fsxData.dwData[0];

                    _planeData = new PlaneData
                    {
                        Location = new Location
                        {
                            Latitude = userPlaneData.Location.Latitude,
                            Longitude = userPlaneData.Location.Longitude,
                            Altitude = userPlaneData.Location.Altitude
                        }
                    };

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _receivedMessage = true;
        }


        // Event handler for closing FSX by user
        public void Fsx_UserClosedFsxEventHandler(SimConnect sender, SIMCONNECT_RECV data)
        {
            CloseFsxConnection();
            _logger.Log("User has closed FSX.");
        }

        // Event handler for exceptions from FSX
        public void Fsx_ExceptionEventHandler(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            // handle exceptions (save to file/display message)
            _logger.Log("Error during connection with FSX.");
        }

        private bool ConnectToFsxIfNecessary()
        {
            if (_simConnect == null)
            {
                _simConnect = FsxFactory.GetSimConnectObject(this);
            }

            if (_simConnect != null)
            {
                return true;
            }

            _logger.Log("Couldn't connect to the FSX.");
            return false;
        }

        private void CloseFsxConnection()
        {
            if (_simConnect == null)
            {
                return;
            }

            _simConnect.Dispose();
            _simConnect = null;
        }
    }
}
