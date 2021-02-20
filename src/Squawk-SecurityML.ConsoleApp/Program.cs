// This file was auto-generated by ML.NET Model Builder. 

using System;
using Squawk_SecurityML.Model;

namespace Squawk_SecurityML.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                Src_Port = 45498F,
                Dst_Port = 22F,
                Protocol = 6F,
                Flow_Duration = 888751F,
                Tot_Fwd_Pkts = 11F,
                Tot_Bwd_Pkts = 11F,
                TotLen_Fwd_Pkts = 1249F,
                TotLen_Bwd_Pkts = 1969F,
                Fwd_Pkt_Len_Max = 736F,
                Fwd_Pkt_Len_Min = 0F,
                Fwd_Pkt_Len_Mean = 113.5455F,
                Fwd_Pkt_Len_Std = 220.8961F,
                Bwd_Pkt_Len_Max = 976F,
                Bwd_Pkt_Len_Min = 0F,
                Bwd_Pkt_Len_Mean = 179F,
                Bwd_Pkt_Len_Std = 364.1865F,
                Flow_Byts_s = 3620.812F,
                Flow_Pkts_s = 24.75384F,
                Flow_IAT_Mean = 42321.48F,
                Flow_IAT_Std = 47851.73F,
                Flow_IAT_Max = 101609F,
                Flow_IAT_Min = 14F,
                Fwd_IAT_Tot = 888751F,
                Fwd_IAT_Mean = 88875.1F,
                Fwd_IAT_Std = 49295.73F,
                Fwd_IAT_Max = 140273F,
                Fwd_IAT_Min = 14F,
                Bwd_IAT_Tot = 788197F,
                Bwd_IAT_Mean = 78819.7F,
                Bwd_IAT_Std = 55863.19F,
                Bwd_IAT_Max = 139285F,
                Bwd_IAT_Min = 72F,
                Fwd_PSH_Flags = @"0",
                Bwd_PSH_Flags = 0F,
                Fwd_URG_Flags = 0F,
                Bwd_URG_Flags = 0F,
                Fwd_Header_Len = 360F,
                Bwd_Header_Len = 360F,
                Fwd_Pkts_s = 12.37692F,
                Bwd_Pkts_s = 12.37692F,
                Pkt_Len_Min = 0F,
                Pkt_Len_Max = 976F,
                Pkt_Len_Mean = 139.913F,
                Pkt_Len_Std = 290.6339F,
                Pkt_Len_Var = 84468.09F,
                FIN_Flag_Cnt = 0F,
                SYN_Flag_Cnt = 0F,
                RST_Flag_Cnt = 0F,
                PSH_Flag_Cnt = 1F,
                ACK_Flag_Cnt = 0F,
                URG_Flag_Cnt = 0F,
                CWE_Flag_Count = 0F,
                ECE_Flag_Cnt = 0F,
                Down_Up_Ratio = 1F,
                Pkt_Size_Avg = 146.2727F,
                Fwd_Seg_Size_Avg = 113.5455F,
                Bwd_Seg_Size_Avg = 179F,
                Fwd_Byts_b_Avg = 0F,
                Fwd_Pkts_b_Avg = 0F,
                Fwd_Blk_Rate_Avg = 0F,
                Bwd_Byts_b_Avg = 0F,
                Bwd_Pkts_b_Avg = 0F,
                Bwd_Blk_Rate_Avg = 0F,
                Subflow_Fwd_Pkts = 11F,
                Subflow_Fwd_Byts = 1249F,
                Subflow_Bwd_Pkts = 11F,
                Subflow_Bwd_Byts = 1969F,
                Init_Fwd_Win_Byts = 14600F,
                Init_Bwd_Win_Byts = 233F,
                Fwd_Act_Data_Pkts = 7F,
                Fwd_Seg_Size_Min = 32F,
                Active_Mean = 0F,
                Active_Std = 0F,
                Active_Max = 0F,
                Active_Min = 0F,
                Idle_Mean = 0F,
                Idle_Std = 0F,
                Idle_Max = 0F,
                Idle_Min = 0F,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Label with predicted Label from sample data...\n\n");
            Console.WriteLine($"Src_Port: {sampleData.Src_Port}");
            Console.WriteLine($"Dst_Port: {sampleData.Dst_Port}");
            Console.WriteLine($"Protocol: {sampleData.Protocol}");
            Console.WriteLine($"Flow_Duration: {sampleData.Flow_Duration}");
            Console.WriteLine($"Tot_Fwd_Pkts: {sampleData.Tot_Fwd_Pkts}");
            Console.WriteLine($"Tot_Bwd_Pkts: {sampleData.Tot_Bwd_Pkts}");
            Console.WriteLine($"TotLen_Fwd_Pkts: {sampleData.TotLen_Fwd_Pkts}");
            Console.WriteLine($"TotLen_Bwd_Pkts: {sampleData.TotLen_Bwd_Pkts}");
            Console.WriteLine($"Fwd_Pkt_Len_Max: {sampleData.Fwd_Pkt_Len_Max}");
            Console.WriteLine($"Fwd_Pkt_Len_Min: {sampleData.Fwd_Pkt_Len_Min}");
            Console.WriteLine($"Fwd_Pkt_Len_Mean: {sampleData.Fwd_Pkt_Len_Mean}");
            Console.WriteLine($"Fwd_Pkt_Len_Std: {sampleData.Fwd_Pkt_Len_Std}");
            Console.WriteLine($"Bwd_Pkt_Len_Max: {sampleData.Bwd_Pkt_Len_Max}");
            Console.WriteLine($"Bwd_Pkt_Len_Min: {sampleData.Bwd_Pkt_Len_Min}");
            Console.WriteLine($"Bwd_Pkt_Len_Mean: {sampleData.Bwd_Pkt_Len_Mean}");
            Console.WriteLine($"Bwd_Pkt_Len_Std: {sampleData.Bwd_Pkt_Len_Std}");
            Console.WriteLine($"Flow_Byts_s: {sampleData.Flow_Byts_s}");
            Console.WriteLine($"Flow_Pkts_s: {sampleData.Flow_Pkts_s}");
            Console.WriteLine($"Flow_IAT_Mean: {sampleData.Flow_IAT_Mean}");
            Console.WriteLine($"Flow_IAT_Std: {sampleData.Flow_IAT_Std}");
            Console.WriteLine($"Flow_IAT_Max: {sampleData.Flow_IAT_Max}");
            Console.WriteLine($"Flow_IAT_Min: {sampleData.Flow_IAT_Min}");
            Console.WriteLine($"Fwd_IAT_Tot: {sampleData.Fwd_IAT_Tot}");
            Console.WriteLine($"Fwd_IAT_Mean: {sampleData.Fwd_IAT_Mean}");
            Console.WriteLine($"Fwd_IAT_Std: {sampleData.Fwd_IAT_Std}");
            Console.WriteLine($"Fwd_IAT_Max: {sampleData.Fwd_IAT_Max}");
            Console.WriteLine($"Fwd_IAT_Min: {sampleData.Fwd_IAT_Min}");
            Console.WriteLine($"Bwd_IAT_Tot: {sampleData.Bwd_IAT_Tot}");
            Console.WriteLine($"Bwd_IAT_Mean: {sampleData.Bwd_IAT_Mean}");
            Console.WriteLine($"Bwd_IAT_Std: {sampleData.Bwd_IAT_Std}");
            Console.WriteLine($"Bwd_IAT_Max: {sampleData.Bwd_IAT_Max}");
            Console.WriteLine($"Bwd_IAT_Min: {sampleData.Bwd_IAT_Min}");
            Console.WriteLine($"Fwd_PSH_Flags: {sampleData.Fwd_PSH_Flags}");
            Console.WriteLine($"Bwd_PSH_Flags: {sampleData.Bwd_PSH_Flags}");
            Console.WriteLine($"Fwd_URG_Flags: {sampleData.Fwd_URG_Flags}");
            Console.WriteLine($"Bwd_URG_Flags: {sampleData.Bwd_URG_Flags}");
            Console.WriteLine($"Fwd_Header_Len: {sampleData.Fwd_Header_Len}");
            Console.WriteLine($"Bwd_Header_Len: {sampleData.Bwd_Header_Len}");
            Console.WriteLine($"Fwd_Pkts_s: {sampleData.Fwd_Pkts_s}");
            Console.WriteLine($"Bwd_Pkts_s: {sampleData.Bwd_Pkts_s}");
            Console.WriteLine($"Pkt_Len_Min: {sampleData.Pkt_Len_Min}");
            Console.WriteLine($"Pkt_Len_Max: {sampleData.Pkt_Len_Max}");
            Console.WriteLine($"Pkt_Len_Mean: {sampleData.Pkt_Len_Mean}");
            Console.WriteLine($"Pkt_Len_Std: {sampleData.Pkt_Len_Std}");
            Console.WriteLine($"Pkt_Len_Var: {sampleData.Pkt_Len_Var}");
            Console.WriteLine($"FIN_Flag_Cnt: {sampleData.FIN_Flag_Cnt}");
            Console.WriteLine($"SYN_Flag_Cnt: {sampleData.SYN_Flag_Cnt}");
            Console.WriteLine($"RST_Flag_Cnt: {sampleData.RST_Flag_Cnt}");
            Console.WriteLine($"PSH_Flag_Cnt: {sampleData.PSH_Flag_Cnt}");
            Console.WriteLine($"ACK_Flag_Cnt: {sampleData.ACK_Flag_Cnt}");
            Console.WriteLine($"URG_Flag_Cnt: {sampleData.URG_Flag_Cnt}");
            Console.WriteLine($"CWE_Flag_Count: {sampleData.CWE_Flag_Count}");
            Console.WriteLine($"ECE_Flag_Cnt: {sampleData.ECE_Flag_Cnt}");
            Console.WriteLine($"Down_Up_Ratio: {sampleData.Down_Up_Ratio}");
            Console.WriteLine($"Pkt_Size_Avg: {sampleData.Pkt_Size_Avg}");
            Console.WriteLine($"Fwd_Seg_Size_Avg: {sampleData.Fwd_Seg_Size_Avg}");
            Console.WriteLine($"Bwd_Seg_Size_Avg: {sampleData.Bwd_Seg_Size_Avg}");
            Console.WriteLine($"Fwd_Byts_b_Avg: {sampleData.Fwd_Byts_b_Avg}");
            Console.WriteLine($"Fwd_Pkts_b_Avg: {sampleData.Fwd_Pkts_b_Avg}");
            Console.WriteLine($"Fwd_Blk_Rate_Avg: {sampleData.Fwd_Blk_Rate_Avg}");
            Console.WriteLine($"Bwd_Byts_b_Avg: {sampleData.Bwd_Byts_b_Avg}");
            Console.WriteLine($"Bwd_Pkts_b_Avg: {sampleData.Bwd_Pkts_b_Avg}");
            Console.WriteLine($"Bwd_Blk_Rate_Avg: {sampleData.Bwd_Blk_Rate_Avg}");
            Console.WriteLine($"Subflow_Fwd_Pkts: {sampleData.Subflow_Fwd_Pkts}");
            Console.WriteLine($"Subflow_Fwd_Byts: {sampleData.Subflow_Fwd_Byts}");
            Console.WriteLine($"Subflow_Bwd_Pkts: {sampleData.Subflow_Bwd_Pkts}");
            Console.WriteLine($"Subflow_Bwd_Byts: {sampleData.Subflow_Bwd_Byts}");
            Console.WriteLine($"Init_Fwd_Win_Byts: {sampleData.Init_Fwd_Win_Byts}");
            Console.WriteLine($"Init_Bwd_Win_Byts: {sampleData.Init_Bwd_Win_Byts}");
            Console.WriteLine($"Fwd_Act_Data_Pkts: {sampleData.Fwd_Act_Data_Pkts}");
            Console.WriteLine($"Fwd_Seg_Size_Min: {sampleData.Fwd_Seg_Size_Min}");
            Console.WriteLine($"Active_Mean: {sampleData.Active_Mean}");
            Console.WriteLine($"Active_Std: {sampleData.Active_Std}");
            Console.WriteLine($"Active_Max: {sampleData.Active_Max}");
            Console.WriteLine($"Active_Min: {sampleData.Active_Min}");
            Console.WriteLine($"Idle_Mean: {sampleData.Idle_Mean}");
            Console.WriteLine($"Idle_Std: {sampleData.Idle_Std}");
            Console.WriteLine($"Idle_Max: {sampleData.Idle_Max}");
            Console.WriteLine($"Idle_Min: {sampleData.Idle_Min}");
            Console.WriteLine($"\n\nPredicted Label value {predictionResult.Prediction} \nPredicted Label scores: [{String.Join(",", predictionResult.Score)}]\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
