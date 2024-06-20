using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;

namespace ip_validator
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _ip1octet;
        private string _ip2octet;
        private string _ip3octet;
        private string _ip4octet;

        private string _binaryIp1octet;
        private string _binaryIp2octet;
        private string _binaryIp3octet;
        private string _binaryIp4octet;

        private string _subnet1octet;
        private string _subnet2octet;
        private string _subnet3octet;
        private string _subnet4octet;

        private string _binarySubnet1octet;
        private string _binarySubnet2octet;
        private string _binarySubnet3octet;
        private string _binarySubnet4octet;

        private string _firstHostAddress;
        private string _lastHostAddress;
        private string _broadcastAddress;
        private int _numberOfHosts;

        public string Ip1octet
        {
            get { return _ip1octet; }
            set
            {
                _ip1octet = value;
                OnPropertyChanged();
                UpdateIPAddress(); // Update IP address whenever any octet changes
            }
        }

        public string Ip2octet
        {
            get { return _ip2octet; }
            set
            {
                _ip2octet = value;
                OnPropertyChanged();
                UpdateIPAddress(); // Update IP address whenever any octet changes
            }
        }

        public string Ip3octet
        {
            get { return _ip3octet; }
            set
            {
                _ip3octet = value;
                OnPropertyChanged();
                UpdateIPAddress(); // Update IP address whenever any octet changes
            }
        }

        public string Ip4octet
        {
            get { return _ip4octet; }
            set
            {
                _ip4octet = value;
                OnPropertyChanged();
                UpdateIPAddress(); // Update IP address whenever any octet changes
            }
        }

        public string BinaryIp1octet
        {
            get { return _binaryIp1octet; }
            set
            {
                _binaryIp1octet = value;
                OnPropertyChanged();
            }
        }

        public string BinaryIp2octet
        {
            get { return _binaryIp2octet; }
            set
            {
                _binaryIp2octet = value;
                OnPropertyChanged();
            }
        }

        public string BinaryIp3octet
        {
            get { return _binaryIp3octet; }
            set
            {
                _binaryIp3octet = value;
                OnPropertyChanged();
            }
        }

        public string BinaryIp4octet
        {
            get { return _binaryIp4octet; }
            set
            {
                _binaryIp4octet = value;
                OnPropertyChanged();
            }
        }

        public string Subnet1octet
        {
            get { return _subnet1octet; }
            set
            {
                _subnet1octet = value;
                OnPropertyChanged();
                UpdateSubnet(); // Update subnet whenever any octet changes
            }
        }

        public string Subnet2octet
        {
            get { return _subnet2octet; }
            set
            {
                _subnet2octet = value;
                OnPropertyChanged();
                UpdateSubnet(); // Update subnet whenever any octet changes
            }
        }

        public string Subnet3octet
        {
            get { return _subnet3octet; }
            set
            {
                _subnet3octet = value;
                OnPropertyChanged();
                UpdateSubnet(); // Update subnet whenever any octet changes
            }
        }

        public string Subnet4octet
        {
            get { return _subnet4octet; }
            set
            {
                _subnet4octet = value;
                OnPropertyChanged();
                UpdateSubnet(); // Update subnet whenever any octet changes
            }
        }

        public string BinarySubnet1octet
        {
            get { return _binarySubnet1octet; }
            set
            {
                _binarySubnet1octet = value;
                OnPropertyChanged();
            }
        }

        public string BinarySubnet2octet
        {
            get { return _binarySubnet2octet; }
            set
            {
                _binarySubnet2octet = value;
                OnPropertyChanged();
            }
        }

        public string BinarySubnet3octet
        {
            get { return _binarySubnet3octet; }
            set
            {
                _binarySubnet3octet = value;
                OnPropertyChanged();
            }
        }

        public string BinarySubnet4octet
        {
            get { return _binarySubnet4octet; }
            set
            {
                _binarySubnet4octet = value;
                OnPropertyChanged();
            }
        }

        public string FirstHostAddress
        {
            get { return _firstHostAddress; }
            set
            {
                _firstHostAddress = value;
                OnPropertyChanged();
            }
        }

        public string LastHostAddress
        {
            get { return _lastHostAddress; }
            set
            {
                _lastHostAddress = value;
                OnPropertyChanged();
            }
        }

        public string BroadcastAddress
        {
            get { return _broadcastAddress; }
            set
            {
                _broadcastAddress = value;
                OnPropertyChanged();
            }
        }

        public int NumberOfHosts
        {
            get { return _numberOfHosts; }
            set
            {
                _numberOfHosts = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            // Initialize properties
            Ip1octet = "";
            Ip2octet = "";
            Ip3octet = "";
            Ip4octet = "";

            Subnet1octet = "";
            Subnet2octet = "";
            Subnet3octet = "";
            Subnet4octet = "";
        }

        private void UpdateIPAddress()
        {
            // Concatenate octets to form the complete IP address
            string ipAddress = $"{Ip1octet}.{Ip2octet}.{Ip3octet}.{Ip4octet}";

            // Validate and convert IP address to binary
            if (IPAddress.TryParse(ipAddress, out IPAddress parsedIpAddress))
            {
                BinaryIp1octet = ConvertToBinary(parsedIpAddress.GetAddressBytes()[0]);
                BinaryIp2octet = ConvertToBinary(parsedIpAddress.GetAddressBytes()[1]);
                BinaryIp3octet = ConvertToBinary(parsedIpAddress.GetAddressBytes()[2]);
                BinaryIp4octet = ConvertToBinary(parsedIpAddress.GetAddressBytes()[3]);

                // Calculate subnet details
                UpdateSubnet();
                CalculateNetworkDetails(parsedIpAddress);
            }
            else
            {
                // Handle invalid IP address input
                BinaryIp1octet = "";
                BinaryIp2octet = "";
                BinaryIp3octet = "";
                BinaryIp4octet = "";

                // Reset subnet and network details
                BinarySubnet1octet = "";
                BinarySubnet2octet = "";
                BinarySubnet3octet = "";
                BinarySubnet4octet = "";

                FirstHostAddress = "";
                LastHostAddress = "";
                BroadcastAddress = "";
                NumberOfHosts = 0;
            }
        }

        private void UpdateSubnet()
        {
            // Concatenate octets to form the complete subnet mask
            string subnetMask = $"{Subnet1octet}.{Subnet2octet}.{Subnet3octet}.{Subnet4octet}";

            // Validate and convert subnet mask to binary
            if (IPAddress.TryParse(subnetMask, out IPAddress parsedSubnet))
            {
                BinarySubnet1octet = ConvertToBinary(parsedSubnet.GetAddressBytes()[0]);
                BinarySubnet2octet = ConvertToBinary(parsedSubnet.GetAddressBytes()[1]);
                BinarySubnet3octet = ConvertToBinary(parsedSubnet.GetAddressBytes()[2]);
                BinarySubnet4octet = ConvertToBinary(parsedSubnet.GetAddressBytes()[3]);
            }
            else
            {
                // Handle invalid subnet mask input
                BinarySubnet1octet = "";
                BinarySubnet2octet = "";
                BinarySubnet3octet = "";
                BinarySubnet4octet = "";
            }
        }

        private string ConvertToBinary(byte octet)
        {
            return Convert.ToString(octet, 2).PadLeft(8, '0');
        }

        private void CalculateNetworkDetails(IPAddress ipAddress)
        {
            // Determine network class
            NetworkClass networkClass = DetermineNetworkClass(ipAddress);
            string ipClass = networkClass.ToString();

            // Calculate subnet information (first host, last host, broadcast, number of hosts)
            byte[] ipBytes = ipAddress.GetAddressBytes();
            byte[] subnetBytes = new byte[4];

            // Get subnet mask bytes
            if (!IPAddress.TryParse($"{Subnet1octet}.{Subnet2octet}.{Subnet3octet}.{Subnet4octet}", out IPAddress subnetAddress))
            {
                return; // Return if subnet mask is invalid
            }

            subnetBytes = subnetAddress.GetAddressBytes();

            // Calculate network address
            byte[] networkAddressBytes = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                networkAddressBytes[i] = (byte)(ipBytes[i] & subnetBytes[i]);
            }

            // Calculate broadcast address
            byte[] broadcastAddressBytes = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                broadcastAddressBytes[i] = (byte)(networkAddressBytes[i] | ~subnetBytes[i]);
            }

            // Determine number of hosts
            byte[] invertedSubnetBytes = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                invertedSubnetBytes[i] = (byte)~subnetBytes[i];
            }

            int numberOfHosts = 1;
            for (int i = 0; i < 4; i++)
            {
                numberOfHosts *= invertedSubnetBytes[i] + 1;
            }

            // Calculate first host, last host
            byte[] firstHostBytes = new byte[4];
            byte[] lastHostBytes = new byte[4];

            Array.Copy(networkAddressBytes, firstHostBytes, 4);
            Array.Copy(broadcastAddressBytes, lastHostBytes, 4);

            firstHostBytes[3] += 1;
            lastHostBytes[3] -= 1;

            FirstHostAddress = new IPAddress(firstHostBytes).ToString();
            LastHostAddress = new IPAddress(lastHostBytes).ToString();
            BroadcastAddress = new IPAddress(broadcastAddressBytes).ToString();
            NumberOfHosts = numberOfHosts;

            // Update IP class text
            string ipClass = DetermineNetworkClass(ipAddress).ToString();
        }

        private NetworkClass DetermineNetworkClass(IPAddress ipAddress)
        {
            byte[] ipBytes = ipAddress.GetAddressBytes();

            if (ipBytes[0] >= 0 && ipBytes[0] <= 127)
            {
                return NetworkClass.A;
            }
            else if (ipBytes[0] >= 128 && ipBytes[0] <= 191)
            {
                return NetworkClass.B;
            }
            else if (ipBytes[0] >= 192 && ipBytes[0] <= 223)
            {
                return NetworkClass.C;
            }
            else if (ipBytes[0] >= 224 && ipBytes[0] <= 239)
            {
                return NetworkClass.D;
            }
            else if (ipBytes[0] >= 240 && ipBytes[0] <= 255)
            {
                return NetworkClass.E;
            }
            else
            {
                return NetworkClass.Unknown;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum NetworkClass
    {
        A,
        B,
        C,
        D,
        E,
        Unknown
    }
}


