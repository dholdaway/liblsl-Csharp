﻿using System;
using LSL;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // wait until an EEG stream shows up
            liblsl.StreamInfo[] results = liblsl.resolve_stream("type", "Markers");

            // open an inlet and print meta-data
            using liblsl.StreamInlet inlet = new liblsl.StreamInlet(results[0]);
            results.DisposeArray();
            Console.Write(inlet.info().as_xml());

            // read samples
            string[] sample = new string[1];
            while (!Console.KeyAvailable)
            {
                inlet.pull_sample(sample);
                Console.WriteLine(sample[0]);
            }
        }
    }
}
