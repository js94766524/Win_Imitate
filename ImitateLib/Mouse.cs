using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitateLib
{
    public static class Mouse
    {
        #region Base

        const int MOVE = 0x0001;                    //移动鼠标 
        const int LEFTDOWN = 0x0002;                //模拟鼠标左键按下 
        const int LEFTUP = 0x0004;                  //模拟鼠标左键抬起 
        const int RIGHTDOWN = 0x0008;               //模拟鼠标右键按下 
        const int RIGHTUP = 0x0010;                 //模拟鼠标右键抬起 
        const int MIDDLEDOWN = 0x0020;              //模拟鼠标中键按下 
        const int MIDDLEUP = 0x0040;                //模拟鼠标中键抬起
        const int WHEEL = 0x0800;                   //模拟鼠标滚轮滚动 
        const int ABSOLUTE = 0x8000;                //标示是否采用绝对坐标 

        readonly static int WIDTH;                  //屏幕宽度
        readonly static int HEIGHT;                 //屏幕高度

        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event( int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo );

        static Mouse()
        {
            try
            {
                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.PrimaryScreen;
                Rectangle b = screen.Bounds;
                WIDTH = b.Width;
                HEIGHT = b.Height;

            }
            catch
            {
                WIDTH = 65536;
                HEIGHT = 65536;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 左键单击
        /// </summary>
        public static void LeftClick( int dx = 0, int dy = 0 )
        {
            mouse_event(LEFTDOWN | LEFTUP, dx * 65536 / WIDTH, dy * 65536 / HEIGHT, 0, 0);
        }

        /// <summary>
        /// 右键单击
        /// </summary>
        public static void RightClick( int dx = 0, int dy = 0 )
        {
            mouse_event(RIGHTDOWN | RIGHTUP, dx * 65536 / WIDTH, dy * 65536 / HEIGHT, 0, 0);
        }

        /// <summary>
        /// 中键单击
        /// </summary>
        public static void MiddleClick( int dx = 0, int dy = 0 )
        {
            mouse_event(MIDDLEDOWN | MIDDLEUP, dx * 65536 / WIDTH, dy * 65536 / HEIGHT, 0, 0);
        }

        /// <summary>
        /// 移动鼠标到指定位置
        /// </summary>
        public static void MoveTo( int dx, int dy )
        {
            mouse_event(ABSOLUTE | MOVE, dx * 65536 / WIDTH, dy * 65536 / HEIGHT, 0, 0);
        }

        /// <summary>
        /// 拖拽到指定位置
        /// </summary>
        public static void DragTo( int dx, int dy )
        {
            mouse_event(LEFTDOWN, 0, 0, 0, 0);
            MoveTo(dx, dy);
            mouse_event(LEFTUP, 0, 0, 0, 0);
        }

        /// <summary>
        /// 按照一个向量移动
        /// </summary>
        public static void MoveTowards( int dx, int dy )
        {
            mouse_event(MOVE, dx * 65536 / WIDTH, dy * 65536 / HEIGHT, 0, 0);
        }

        /// <summary>
        /// 按照一个向量拖拽
        /// </summary>
        public static void DragTowards( int dx, int dy )
        {
            mouse_event(LEFTDOWN, 0, 0, 0, 0);
            MoveTowards(dx, dy);
            mouse_event(LEFTUP, 0, 0, 0, 0);
        }

        /// <summary>
        /// 滚动鼠标滚轮
        /// </summary>
        /// <param name="towards">正数为向下滚动，负数为向上滚动，数值为滚动距离</param>
        public static void WheelRoll( int towards )
        {
            mouse_event(WHEEL, 0, 0, -towards, 0);
        }

        #endregion
    }
}
