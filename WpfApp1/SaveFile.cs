using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class SaveFile
    {
        byte[] saveTemp;
        public static int IJ_LONDON_MISSIONS = 0;
        public static int IJ_TURIN_MISSIONS = 1;
        public static int IJ_ALPS_MISSIONS = 2;


        int[] IJLondon = { 16, 12, 14, 20, 18, 26, 22 };
        int[] IJTurin = { 24,152, 150, 156, 154, 158 };
        int[] IJAlps = { 162, 160 };
        ArrayList ItalianJobMissions = new ArrayList();

        int[] CLondon = { 48, 52, 56, 44, 42, 64, 40, 60, 62 };
        int[] CTurin = {72, 74, 76, 78, 80, 82, 84, 86, 88};
        ArrayList CheckpointMissions = new ArrayList();

        int[] DLondon = { 108, 106, 100, 94, 34, 102, 96, 32, 104, 92 };
        int[] DTurin = { 194, 190, 192, 196, 204, 198, 168, 200, 202, 206 };
        ArrayList DestructorMissions = new ArrayList();

        int[] Challenges = { 38, 50, 36, 46, 30, 186, 70, 188, 68 };
        ArrayList ChallengeMissions = new ArrayList();

        int[] all = {166 };
        ArrayList allList = new ArrayList();


        String fileName;
        

        public SaveFile(String fileName)
        {
            this.fileName = fileName;
            ItalianJobMissions.Add(IJLondon);
            ItalianJobMissions.Add(IJTurin);
            ItalianJobMissions.Add(IJAlps);

            CheckpointMissions.Add(CLondon);
            CheckpointMissions.Add(CTurin);

            DestructorMissions.Add(DLondon);
            DestructorMissions.Add(DTurin);

            ChallengeMissions.Add(Challenges);

            allList.Add(all);

            saveTemp = File.ReadAllBytes(fileName);
            System.Console.WriteLine("Read file. Length of: " + saveTemp.Length);
            foreach (Byte a in saveTemp)
            {
                System.Console.Write((int)a);
            }
        }

        public Boolean[] isAllSet()
        {
            Boolean[] set = { true };

            foreach (int[] b in allList)
            {
                foreach (int a in b)
                {
                    if (saveTemp[a] == 0)
                    {
                        set[allList.IndexOf(b)] = false;
                        break;
                    }
                }
            }
            return set;
        }

        public void setAll(Boolean set, int i)
        {
            System.Console.WriteLine(set);
            foreach (int a in (int[])allList[i])
            {

                if (set == true)
                {
                    saveTemp[a] = 1;
                }
                else
                {
                    saveTemp[a] = 0;
                }
            }
        }



        public Boolean[] isChallengeMissionsSet()
        {
            Boolean[] set = { true};

            foreach (int[] b in ChallengeMissions)
            {
                foreach (int a in b)
                {
                    if (saveTemp[a] == 0)
                    {
                        set[ChallengeMissions.IndexOf(b)] = false;
                        break;
                    }
                }
            }
            return set;
        }

        public void setChallengeMissions(Boolean set, int i)
        {
            System.Console.WriteLine(set);
            foreach (int a in (int[])ChallengeMissions[i])
            {

                if (set == true)
                {
                    saveTemp[a] = 1;
                }
                else
                {
                    saveTemp[a] = 0;
                }
            }
        }

        public Boolean[] isDMissionsSet()
        {
            Boolean[] set = { true, true };

            foreach (int[] b in DestructorMissions)
            {
                foreach (int a in b)
                {
                    if (saveTemp[a] == 0)
                    {
                        set[DestructorMissions.IndexOf(b)] = false;
                        break;
                    }
                }
            }
            return set;
        }

        public void setDestructorMissions(Boolean set, int i)
        {
            System.Console.WriteLine(set);
            foreach (int a in (int[])DestructorMissions[i])
            {

                if (set == true)
                {
                    saveTemp[a] = 1;
                }
                else
                {
                    saveTemp[a] = 0;
                }
            }
        }

        public Boolean[] isCMissionsSet()
        {
            Boolean[] set = { true, true };

            foreach (int[] b in CheckpointMissions)
            {
                foreach (int a in b)
                {
                    if (saveTemp[a] == 0)
                    {
                        set[CheckpointMissions.IndexOf(b)] = false;
                        break;
                    }
                }
            }
            return set;
        }

        public void setCheckpointMissions(Boolean set, int i)
        {
            System.Console.WriteLine(set);
            foreach (int a in (int[])CheckpointMissions[i])
            {

                if (set == true)
                {
                    saveTemp[a] = 1;
                }
                else
                {
                    saveTemp[a] = 0;
                }
            }
        }

        public Boolean[] isIJMissionsSet()
        {
            Boolean[] set = { true, true, true };
            
            foreach(int[] b in ItalianJobMissions){
                foreach (int a in b)
                {
                    if (saveTemp[a] == 0)
                    {
                        set[ItalianJobMissions.IndexOf(b)] = false;
                        break;
                    }
                }
            }
            return set;
        }

        public void setIJMissions(Boolean set, int i)
        {
            System.Console.WriteLine(set);
            foreach(int a in (int[])ItalianJobMissions[i])
            {

                if(set == true)
                {
                    saveTemp[a] = 1;
                }
                else
                {
                    saveTemp[a] = 0;
                }   
            } 
        }

        public void Write()
        {
            var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            fs.Write(saveTemp, 0, saveTemp.Length);
            fs.Close();
        }




    }
}
