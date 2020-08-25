using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace syntiks
{
    class makesound
    {

        private const int SAMPLE_RATE = 44100;
        private const short BITS_PER_SAMPLE = 16;



        public makesound()
        {
        }

        public static bool OSC(float freq, List<int> statelist, List<int> vola, List<int> lfo_f, List<int> lfo_a, List<int> pitch_b)
        {
            short[] wave = new short[SAMPLE_RATE];
            byte[] Bwave = new byte[SAMPLE_RATE * sizeof(short)];
            int osc_count = 0;

            for (int x = 0; x < statelist.Count(); x++)
            {
                if (statelist[x] != 0)
                {
                    osc_count++;
                }
            }
            float amp = 0;

            for (int state = 0; state < statelist.Count(); state++)
            {
                if (statelist[state] != 0)
                {
                    int State = statelist[state];
                    amp = (float)vola[state] / 100;
                    float lfo_amount = (float)lfo_a[state] / 10;
                    float pitchboost = (float)pitch_b[state] / 5;
                    int lfo_speed = lfo_f[state];
                    short tempsample;
                  

                    //statehommien hoitelu
                    switch (State)
                    {
                        case 1:
                            for (int i = 0; i < SAMPLE_RATE; i++)
                            {
                                wave[i] += Convert.ToInt16(((short.MaxValue * amp) * Math.Sin(((Math.PI * 2 * (freq * pitchboost + lfo_amount * Math.Sin(((Math.PI * 2 * lfo_speed) / SAMPLE_RATE) * i))) / SAMPLE_RATE) * i)) / osc_count);
                            }
                            break;
                        case 2:
                            for (int i = 0; i < SAMPLE_RATE; i++)
                            {
                                wave[i] += Convert.ToInt16((short.MaxValue * amp) * Math.Sign(Math.Sin(((Math.PI * 2 * (freq * pitchboost + lfo_amount * Math.Sin(((Math.PI * 2 * lfo_speed) / SAMPLE_RATE) * i))) / SAMPLE_RATE) * i)) / osc_count);
                            }
                            break;
                        case 3:
                            for (int i = 0; i < SAMPLE_RATE; i++)
                            {
                                tempsample = (short)(-short.MaxValue*amp);
                                int sampleperwavelenght = (int)(SAMPLE_RATE / (freq*pitchboost+ lfo_amount * Math.Sin(((Math.PI * 2 * lfo_speed) / SAMPLE_RATE) * i)));
                                short ampstep = (short)(((short.MaxValue * 2 * amp) / sampleperwavelenght));

                                for (int j = 0; j<sampleperwavelenght && i < SAMPLE_RATE; j++)
                                {
                                    tempsample += ampstep;
                                    wave[i++] += Convert.ToInt16(tempsample);
                                }
                            }
                            break;
                        case 4:
                            tempsample = -short.MaxValue;
                            for (int i = 0; i < SAMPLE_RATE; i++)
                            {
                                int sampleperwavelenght = (int)(SAMPLE_RATE / (freq * pitchboost + lfo_amount * Math.Sin(((Math.PI * 2 * lfo_speed) / SAMPLE_RATE) * i)));
                                short ampstep = (short)(((short.MaxValue * 2) / sampleperwavelenght));

                                if (Math.Abs(tempsample + ampstep) > 0)
                                {
                                    ampstep = (short)-ampstep;
                                }
                                tempsample += ampstep;
                                wave[i++] += Convert.ToInt16((short)(tempsample*amp));
                            }
                            break;
                    }
                }
            }
            Buffer.BlockCopy(wave, 0, Bwave, 0, wave.Length * sizeof(short));
            using(MemoryStream memorystream = new MemoryStream())
            using(BinaryWriter binarywriter = new BinaryWriter(memorystream))
            {

                short blockalign = BITS_PER_SAMPLE / 8;
                int subchunk = SAMPLE_RATE*blockalign;

                binarywriter.Write(new[] {'R','I','F','F'});
                binarywriter.Write(36 + subchunk);
                binarywriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
                binarywriter.Write(16);
                binarywriter.Write((short)1);
                binarywriter.Write((short)1);
                binarywriter.Write(SAMPLE_RATE);
                binarywriter.Write(SAMPLE_RATE*blockalign);
                binarywriter.Write(blockalign);
                binarywriter.Write(BITS_PER_SAMPLE);
                binarywriter.Write(new[] { 'd', 'a', 't', 'a' });
                binarywriter.Write(subchunk);
                binarywriter.Write(Bwave);
                memorystream.Position = 0;
                new SoundPlayer(memorystream).Play();

            }
            return true;
        }
    }
}
