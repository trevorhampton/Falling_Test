﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Falling_Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Accelerometer accelerometer;
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (accelerometer == null)
            {
                accelerometer = new Accelerometer();
                accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(20);
                //accelerometer.CurrentValueChanged +=
                //    new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged);

            }
            try
            {
                statusTextBlock.Text = "Starting accelerometer";
                accelerometer.Start();
            }
            catch (InvalidOperationException ex)
            {
                statusTextBlock.Text = "Unable to start accelerometer.";
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void testBtn_Click(object sender, RoutedEventArgs e)
        {
            distanceText.Text = accelerometer.CurrentValue.ToString();
        }

        void accelerometer_CurrentValueChanged(AccelerometerReading accelerometerReading)
        {
            statusTextBlock.Text = "Getting data.";

            Vector3 acceleration = accelerometerReading.Acceleration;

            velocityText.Text = "Acceleration Output: " + acceleration.Z.ToString("0.00");
            
        }
    }
}
