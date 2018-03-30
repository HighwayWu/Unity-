# Unity-001

# Unity之万丈高楼第一砖

第一次接触Unity，感觉还是挺好玩的。

跟着教程做了个愤怒的小鸟，实现了基本的功能（除了关卡只设计了9关以外。。）

了解了Unity许多的基本功能，比如刚体、碰撞体、SpringJoint。。

几个印象比较深刻的"bug":
1、层级渲染：从上到下（从内到外）依次渲染，所以全屏覆盖的UI必须放在其他UI上方，否则其他UI点击无效。（还以为是按钮的点击事件有问题。。debug了半天）
2、PlayerPrefs：生成PC版应用时根据company、product name来保存数据在注册表内，所以删除_Data文件夹并不能清除保存的数据。
3、分辨率：悲剧的我从头到尾使用free aspect，结果最后锚点啥的调了半天的分辨率。。切记一开始就调好分辨率/比。

![image](http://github.com/HighwayWu/Unity-001/raw/master/AngerBirds/图片1.jpg)
![image](http://github.com/HighwayWu/Unity-001/raw/master/AngerBirds/图片2.jpg)
![image](http://github.com/HighwayWu/Unity-001/raw/master/AngerBirds/图片3.jpg)
![image](http://github.com/HighwayWu/Unity-001/raw/master/AngerBirds/图片4.jpg)
![image](http://github.com/HighwayWu/Unity-001/raw/master/AngerBirds/图片5.jpg)

PC版在PC文件夹下，安卓APK在AndroidAPK文件夹下。
