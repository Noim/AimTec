using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using AimWard.Menus;
using System.Collections.Generic;
using System.Drawing;

namespace AimWard.Fuctions
{
    class Functions
    {
        private static List<Vector3> wardLocations;
        public static List<Vector3> WardLocations
        {
            get
            {
                if (wardLocations == null)
                {
                    wardLocations = new List<Vector3>
                    {
                        new Vector3(12731.25f, 50.32f, 9132.66f),
                        new Vector3(5583.74f, 51.43f, 3573.83f),
                        new Vector3(9757.9f, 50.73f, 8768.25f),
                        new Vector3(9211.42f, 53.16f, 11480.54f),
                        new Vector3(6483.73f, 60.0f, 4606.57f),
                        new Vector3(1711.55f, 52.49f, 12998.53f),
                        new Vector3(1213.70f, 58.77f, 5324.73f),
                        new Vector3(3063.29f, -67.48f, 10905.67f),
                        new Vector3(9795.85f, -12.21f, 6355.15f),
                        new Vector3(2757.31f, 52.94f, 5194.54f),
                        new Vector3(8120.67f, 60.0f, 8110.15f),
                        new Vector3(5571.69f, 56.83f, 11101.82f),
                        new Vector3(11786.12f, -70.71f, 4106.47f),
                        new Vector3(12523.26f, 57.0f, 1635.91f),
                        new Vector3(5704.763f, 52.83f, 12762.87f),
                        new Vector3(5217.58f, 77.63f, 1288.98f),
                        new Vector3(4882.86f, 27.83f, 8393.77f),
                        new Vector3(7202.43f, 53.18f, 9881.83f),
                        new Vector3(4717.09f, 50.83f, 7142.35f),
                        new Vector3(7018.75f, 54.76f, 11362.12f),
                        new Vector3(4232.69f, 47.56f, 11869.25f),
                        new Vector3(6951.01f, 52.26f, 3040.55f),
                        new Vector3(7831.46f, 60.0f, 3501.13f),
                        new Vector3(10586.62f, 60.0f, 3067.93f),
                        new Vector3(8198.22f, 49.38f, 10267.89f),
                        new Vector3(9704.83f, 52.30f, 11848.35f),
                        new Vector3(11600.35f, 51.73f, 7090.37f),
                        new Vector3(8036.52f, 45.19f, 12882.94f),
                        new Vector3(9551.15f, 60.83f, 137.19f),
                        new Vector3(8598.335f, 51.93f, 4729.91f),
                        new Vector3(5363.31f, -62.70f, 9157.05f),
                        new Vector3(13258.06f, 51.36f, 2463.80f),
                        new Vector3(7610.46f, 60.0f, 5000.0f),
                        new Vector3(7216.65f, 52.83f, 14115.32f),
                        new Vector3(7761.92f, 49.44f, 842.31f),
                        new Vector3(3261.93f, 60.0f, 7773.65f),
                        new Vector3(6526.12f, -71.21f, 8367.01f),
                        new Vector3(14052.25f, 52.30f, 6988.55f),
                        new Vector3(10546.35f, -60.0f, 5019.06f),
                        new Vector3(9344.95f, -64.07f, 5703.43f),
                        new Vector3(10074.63f, 51.74f, 7761.62f),
                        new Vector3(4334.98f, -60.42f, 9714.54f),
                        new Vector3(7836.85f, 56.48f, 11906.34f),
                        new Vector3(4281.39f, 71.63f, 4467.51f),
                        new Vector3(12629.72f, 48.62f, 4908.16f),
                        new Vector3(2398.38f, 52.83f, 13521.84f),
                        new Vector3(4749.79f, 53.59f, 5890.76f),
                        new Vector3(9736.8f, 51.98f, 6916.26f),
                        new Vector3(11398.03f, 50.64f, 1440.97f),
                        new Vector3(9200.85f, 56.45f, 3824.71f),
                        new Vector3(5488.53f, 51.03f, 5657.80f),
                        new Vector3(9255.25f, 57.5f, 2183.65f),
                        new Vector3(1262.71f, 52.83f, 12310.28f),
                        new Vector3(5172.51f, 51.05f, 3116.71f),
                        new Vector3(6623.58f, 51.85f, 6973.31f),
                        new Vector3(12017.83f, 52.30f, 9787.35f),
                        new Vector3(805.90f, 52.83f, 8138.49f),
                        new Vector3(11573.9f, 51.71f, 6457.76f),
                        new Vector3(9176.99f, 52.51f, 9367.65f),
                        new Vector3(2222.31f, 53.2f, 9964.1f),
                        new Vector3(8417.12f, -71.24f, 6521.46f)
                    };
                }

                return wardLocations;
            }
        }

        public static Vector3? ScanWardLocation()
        {
            foreach (Vector3 wardPos in WardLocations)
            {
                if (wardPos.Distance(Game.CursorPos) <= 250.0 && wardPos.Distance(Program.Player.Position) <= 650.0)
                    return wardPos;
            }

            return null;
        }

        public static void DrawWardLocation()
        {
            foreach (Vector3 wardPos in WardLocations)
            {
                if (Program.Player.ServerPosition.Distance(wardPos) < AimMenu.Menu["drawDistanceFromWard"].As<MenuSlider>().Value)
                    Render.Circle(wardPos, 30.0f, 100, ((wardPos.Distance(Game.CursorPos) <= 250.0) ? Color.Red : Color.LawnGreen));
            }
        }

        private static List<WallWardData> wallWardLocations;
        public static List<WallWardData> WallWardLocations
        {
            get
            {
                if (wallWardLocations == null)
                {
                    wallWardLocations = new List<WallWardData>
                    {
                        // Blue Side - Red Buff
				        new WallWardData(new Vector3(8038.775f, 53.72073f, 4275.063f),
                                        new Vector3(8461.842f, 50.60168f, 4654.9f),
                                        new Vector3(8523.9f, 51.24f, 4707.76f)),

                        // Blue Side - Golems To Red Buff
				        new WallWardData(new Vector3(8257.502f, 51.13f, 2910.066f),
                                        new Vector3(8170.634f, 51.76062f, 3438.465f),
                                        new Vector3(8170.634f, 51.76062f, 3438.465f)),

                        // Blue Side - Tower To Jungle
				        new WallWardData(new Vector3(6874.0f, 50.52f, 1708.0f),
                                        new Vector3(6849.11f, 50.52f, 2252.01f),
                                        new Vector3(6723.9f, 52.17f, 2507.76f)),

                        // Blue Side - Top Mid To River
				        new WallWardData(new Vector3(5980.0f, 51.65339f, 7554.0f),
                                        new Vector3(6197.479f, -67.07629f, 8112.845f),
                                        new Vector3(6197.479f, -67.07629f, 8112.845f)),

                        // Blue Side - Mid River To Ambush
				        new WallWardData(new Vector3(5795.822f, -70.93462f, 8384.079f),
                                            new Vector3(5252.114f, 29.05359f, 8238.521f),
                                            new Vector3(5123.9f, -21.23f, 8457.76f)),

                        // Blue Side - Bottom Mid To River
				        new WallWardData(new Vector3(7784.667f, 51.91295f, 6007.736f),
                                        new Vector3(8248.607f, -71.24072f, 6421.765f),
                                        new Vector3(8248.607f, -71.24072f, 6421.765f)),

                        // Blue Side - Jungle To River
				        new WallWardData(new Vector3(2750.054f, 54.3255f, 10319.73f),
                                        new Vector3(2905.962f, -76.8251f, 10815.45f),
                                        new Vector3(3022.79f, -68.84045f, 10788.25f)),

                        // Blue Side - Top To River
				        new WallWardData(new Vector3(1774.0f, 52.8381f, 10901.75f),
                                        new Vector3(2381.939f, -71.2406f, 11021.48f),
                                        new Vector3(2821.113f, -71.24036f, 11254.26f)),

                        // Baron To Tri
				        new WallWardData(new Vector3(4729.881f, -71.2406f, 10839.61f),
                                        new Vector3(4532.287f, 51.24414f, 11418.29f),
                                        new Vector3(4521.676f, 51.98792f, 11469.82f)),

                        // Dragon To Tri
				        new WallWardData(new Vector3(10072.0f, -71.24f, 3908.0f),
                                        new Vector3(10297.93f, 49.03f, 3358.59f),
                                        new Vector3(10273.9f, 49.03f, 3257.76f)),

				        // Purple Side - Jungle To River
				        new WallWardData(new Vector3(12422.0f, 51.7294f, 4508.0f),
                                        new Vector3(12353.94f, 51.73f, 4031.58f),
                                        new Vector3(11960.99f, -66.58813f, 3932.363f)),

                        // Purple Side - Top Mid To River
				        new WallWardData(new Vector3(7287.894f, 52.8726f, 8520.936f),
                                        new Vector3(6790.03f, -71.24072f, 8562.474f),
                                        new Vector3(6790.03f, -71.24072f, 8562.474f)),

                        // Purple Side - Bottom Mid To River
				        new WallWardData(new Vector3(9072.0f, 53.04f, 7158.0f),
                                        new Vector3(8705.95f, 53.04f, 6819.1f),
                                        new Vector3(8654.766f, -71.24072f, 6741.225f)),

                        // Purple Side - Golems To Red Buff
				        new WallWardData(new Vector3(6574.0f, 56.48f, 12006.0f),
                                        new Vector3(6678.08f, 56.48f, 11477.83f),
                                        new Vector3(6678.08f, 53.85f, 11477.83f)),

                        // Purple Side - Tower To Jungle
				        new WallWardData(new Vector3(8127.036f, 52.8381f, 13187.44f),
                                        new Vector3(8227.608f, 56.52844f, 12676.1f),
                                        new Vector3(8323.9f, 56.48f, 12457.76f)),

                        // Purple Side - Mid River To Ambush
                        new WallWardData(new Vector3(9028.257f, -71.2406f, 6551.627f),
                                            new Vector3(9642.994f, 24.96692f, 6642.71f),
                                            new Vector3(9773.9f, 9.56f, 6457.76f))
                    };
                }

                return wallWardLocations;
            }
        }

        public static WallWardData ScanWallWardLocation()
        {
            foreach (WallWardData wardPos in WallWardLocations)
            {
                if (wardPos.WallLocation.Distance(Game.CursorPos) <= 100.0 && wardPos.WallLocation.Distance(Program.Player.Position) <= 400.0)
                    return wardPos;
            }

            return null;
        }

        public static void DrawWallWardLocation()
        {
            foreach (WallWardData wardPos in WallWardLocations)
            {
                Color wardColor = (wardPos.WallLocation.Distance(Game.CursorPos) <= 100.0) ? Color.Red : Color.LawnGreen;
                Color arrowColor = (wardPos.WallLocation.Distance(Game.CursorPos) <= 250.0) ? Color.Green : Color.FromArgb(0, 255, 255, 255);

                if (Program.Player.ServerPosition.Distance(wardPos.WallLocation) < AimMenu.Menu["drawDistanceFromWard"].As<MenuSlider>().Value)
                {
                    Render.Circle(wardPos.WardPosition, 30.0f, 100, wardColor);
                    Render.Circle(wardPos.WallLocation, 100.0f, 100, wardColor);

                    Vector3 directionVector = (wardPos.WardPosition - wardPos.WallLocation);
                    directionVector.Normalize();

                    float length = (wardPos.WardPosition - wardPos.WallLocation).Length;

                    Vector3 finalLocation = new Vector3(wardPos.WallLocation.X + (directionVector.X * length),
                                                    wardPos.WallLocation.Y + (directionVector.Y * length),
                                                    wardPos.WallLocation.Z + (directionVector.Z * length));

                    Render.WorldToScreen(wardPos.WallLocation, out Vector2 screenMagneticPos);
                    Render.WorldToScreen(finalLocation, out Vector2 screenDirectionVector);
                    Render.Line(screenMagneticPos, screenDirectionVector, 2f, true, arrowColor);
                }
            }
        }
    }

    public class WallWardData
    {
        public Vector3 WallLocation { get; private set; }

        public Vector3 PlaceLocation { get; private set; }

        public Vector3 WardPosition { get; private set; }

        public WallWardData(Vector3 wallLocation, Vector3 placeLocation, Vector3 wardPosition)
        {
            WallLocation = wallLocation;
            PlaceLocation = placeLocation;
            WardPosition = wardPosition;
        }
    }
}
