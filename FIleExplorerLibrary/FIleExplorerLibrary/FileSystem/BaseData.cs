﻿using System;

namespace FileSystem
{
    public abstract class BaseData
    {
        protected internal event FileManagerStateHandler Copied;
        protected internal event FileManagerStateHandler Created;
        protected internal event FileManagerStateHandler Deleted;
        protected internal event FileManagerStateHandler Moved;
        protected internal event FileManagerStateHandler Opened;
        protected internal event FileManagerStateHandler Renamed;

        public delegate void FileManagerStateHandler(string message);
        public string Path { get; protected set; }





        public abstract void Copy(string newPath);

        public abstract void Create(string name);

        public abstract void Delete(string name);

        public abstract void Move(string newPath);

        public abstract void Rename(string newName);



        internal static string GetNameFromPath(string path)
        {
            try
            {
                int separatorIndex = path.LastIndexOf(@"\") + 1; // doesn't count the last backslash
                string name = path.Substring(separatorIndex);
                return name;
            }
            catch (Exception exception)
            {
                return "Couldn't get the name from path" + exception.Message;
            }
        }


        public void SetEventHandlers(FileManagerStateHandler copied, FileManagerStateHandler created,
            FileManagerStateHandler deleted, FileManagerStateHandler moved, FileManagerStateHandler opened, FileManagerStateHandler renamed)
        {
            Copied += copied;
            Created += created;
            Deleted += deleted;
            Moved += moved;
            Opened += opened;
            Renamed += renamed;
        }


        protected void SetEvent(string eventType, string message)
        {
            switch (eventType)
            {
                case "Copied":
                    Copied?.Invoke(message);
                    break;
                case "Created":
                    Created?.Invoke(message);
                    break;
                case "Deleted":
                    Deleted?.Invoke(message);
                    break;
                case "Moved":
                    Moved?.Invoke(message);
                    break;
                case "Opened":
                    Opened?.Invoke(message);
                    break;
                case "Renamed":
                    Renamed?.Invoke(message);
                    break;
                default:
                    throw new Exception("Didn't find this event");
            }
        }
    }
}
