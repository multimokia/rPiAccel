# rPiAccel 
A fun side project using dotnet core project for reading accelerometer data from an [MPU6050 module](https://components101.com/sensors/mpu6050-module) using the GPIO Pins on a Raspberry Pi.

## Wire up

The digram below shows how to wire up the MPU6050 module to the Raspberry Pi.

![MPU6050](./Docs/mpu6050_wiring.jpg)

## Building and running the code

In order to build the code in a manner it can be run on the raspberry pi (without installing any additional software) you need to run the following commands:

    dotnet  publish --self-contained true --runtime linux-x64

then copy the resulting files to the a directory of your choosing on the raspberry pi.

Once your files are on the raspberry pi you can run the following command to run the program:

    dotnet run rPiAccel

This will run the program and display the accelerometer data on the screen.

The program will run until you press the `q` (or indeed any other) key. 


