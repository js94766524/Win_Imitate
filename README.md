#### Win_Imitate

本库包含两个子项目，其中Imitate是演示项目，ImitateLib是dll项目。

当你需要用代码模拟鼠标和键盘的操作时，添加ImitateLib的引用即可。

#### ImitateLib

主要包含两个静态类：

1. Keyboard
	- 模拟键盘的普通输入使用Keyboard.Press(params Keys[] inputs)方法
    - 模拟Ctrl、Alt、Shift组合字母按键时，分别调用相应的Ctrl、Alt、Shift方法
    - 在确保目标控件有输入焦点的情况下，调用Keyboard.InputByClipboard(string data)方法可以将data字符串的内容以从剪切板粘贴的形式输入到控件中

2. Mouse
	- 模拟鼠标移动到绝对位置：Mouse.MoveTo(x,y)
    - 模拟鼠标移动到相对位置：Mouse.MoveTowards(x,y)
    - 模拟左键、中键、右键的点击：Mouse.LeftClick/MiddleClick/RightClick(int x = 0,int y = 0)
    - 从当前位置开始拖拽鼠标到绝对位置：Mouse.DragTo(x,y)
    - 从当前位置开始拖拽鼠标到相对位置：Mouse.DragTowards(x,y)
    - 模拟鼠标滚轮滚动：Mouse.WheelRoll(int towards) 
        - towards>0 为向下滚动，towards的大小为滚动的范围
