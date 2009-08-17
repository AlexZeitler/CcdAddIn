using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CcdAddIn
{
    /// <summary>
    /// nuetzliche helferlein
    /// </summary>
    public static class CcdAddInUtil
    {
        /// <summary>
        /// loest komplexe pfadangaben unter zuhilfenahme der Uri-Klasse auf: z.b.:
        /// "\\server\share\dir1\dir2\..\file.txt" -> "\\server\share\dir1\file.txt"
        /// "http://server/share/dir1/dir2/../file.txt" -> "http://server/share/dir1/file.txt"
        /// fuer _absolute_ pfadangaben mit server-angabe, kann man diese Funktion benutzen,
        /// da die Uri-Klasse das prima implementiert. bei relativen pfaden wird daraus leider nix
        /// und dann wird auf NormalizePathC() verwiesen 
        /// </summary>
        /// <param name="path">pfad</param>
        /// <returns>pfad</returns>
        public static string NormalizePath(string path)
        {
            try
            {
                Uri u = new Uri(path);
                if (u.Scheme == "http")
                {
                    return u.AbsoluteUri;
                }
                if (u.Scheme == "file")
                {
                    return u.LocalPath;
                }
                // failsafe
                return u.ToString();
            }
            catch
            {
                // failsafe
                return ( NormalizePathC( path ) ) ;
            }
        }

        /// <summary>
        /// löst komplexe pfadangaben auf: z.b.:
        /// "{anyPath}\..\.\file.txt" -> "{anyPath}\file.txt"
        /// im gegensatz zu NormalizePath() kann dieses kerlchen auch 
        /// mit realtiven pfadangaben umgehen 
        /// </summary>
        /// <param name="path">pfad</param>
        /// <returns>pfad</returns>
        public static string NormalizePathC(string path)
        {
            try
            {
                string normailzedPath = path;
                normailzedPath = normailzedPath.Replace("\\\\", "//");  // doppel backslashes durch doppelslash 
                normailzedPath = normailzedPath.Replace("\\", "/");     // jetzt die verbliebenen einfachen durch einfache
                normailzedPath = normailzedPath.Replace("/./", "/");    // "c:/level1/level2/./level3" --> "c:/level1/level2/level3"

                // nun der tricky part mit den ".." referenzen
                string[] pathItems = normailzedPath.Split('/');
                List<string> newPathItems = new List<string>();
                for (int i = 0; i < pathItems.Length; i++)
                {
                    if (pathItems[i] == "..")
                    {   // das letzte element der neuen liste muss neutralisiert werden
                        if (newPathItems.Count > 0)
                        {   // entfernen geht natuerlich nur, wo es was zu entfernen gibt ;)
                            newPathItems.RemoveAt(newPathItems.Count - 1);
                        }

                        // ein sonderfall ist allerdinx, wenn nur "..\level2" reingereicht wurde 
                        // dann muss das erste element _leider_ doch ueberommen werden, weil
                        // was sollten wir da sonst setzen ;)
                        if (i == 0)
                        {
                            newPathItems.Add(pathItems[i]);
                        }
                    }
                    else
                    {
                        newPathItems.Add(pathItems[i]);
                    }
                }

                // jetzt aus den ermittelten elementen den 
                // kompletten pfad aufbauen !
                normailzedPath = "";
                for (int i = 0; i < newPathItems.Count; i++)
                {
                    normailzedPath += newPathItems[i];
                    if (i < newPathItems.Count - 1)
                    {
                        normailzedPath += "/";
                    }
                }
                // spezeil fuer "//server/share/dir"
                if (normailzedPath.StartsWith("//"))
                {
                    normailzedPath = normailzedPath.Replace("//", @"\\");
                    normailzedPath = normailzedPath.Replace("/", @"\");
                }
                // jetzt noch den spezialfall "./{pfad}" verfrühstücken
                if (normailzedPath.StartsWith("./"))
                {
                    normailzedPath = normailzedPath.Remove(0, 2);
                }

                return normailzedPath;
            }
            catch 
            {
                // failsafe
                return path;

            }
        }

    } // namespace

} // class
