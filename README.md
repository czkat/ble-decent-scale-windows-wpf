# BLE Decent Scale WPF
This code is used for establishing BluetoothLE connection from a bluetooth device Decent Scale to windows PC.

How to use the code:
1. Create new WPF application with NET6.0.
2. Install pythonnet from nuget package manager, current latest ver 3.0.1.
3. Download python package pydecentscale (see below).
4. Change output type to console, from Project - wpfapp1 properties - Application - General - Output Type -> Console Application.
5. To use the code from MainWindow.xaml.cs, change file location of python dll and folder location of pydecentscale.

Big thanks to lucapinello for the python package pydecent scale here https://github.com/lucapinello/pydecentscale.
