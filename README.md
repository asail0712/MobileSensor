> ## 簡介
> 使用Unity去抓取行動裝置上的加速度感應器與陀螺儀的資料，測試並應用其數據對於虛擬世界進行操作或是改變。最終目的是使用該測試結果，將相關功能套件化，加進XPlan。
> 
> ## 使用到的功能
>  主要使用Unity的Input.gyro與Input.acceleration，兩個功能。
>  
> ## 遇到問題與解決
> 無
> ## 日誌
> 2024.7.18  
> 加速度感應器不光是能感受到行動裝置本身移動時的加速度，並且同時會受到重力影響。為了得到單純的移動加速度時，使用不熟悉的四元數計算時，花了點時間。
>
> 
> 2024.7.19  
> 雖然加速度感應器能感應到手機的加速度變化，但是精準度有待加強，無法準確模擬出手機在現實空間中的移動，因此將停止嘗試，改使用AR Foundation
> 
> 
> ##  其他
> 無
> 
> ## 參考資料
> 1. [Unity - how to make a player controller with gyroscope and accelerometer](https://www.youtube.com/watch?v=jvwX5WthM2o)
> 2. [Unity Gyroscope tutorial | use phones Gyroscope as Input](https://www.youtube.com/watch?v=V_fJnhw8p3g)



> ## Introduction
> Using Unity to capture data from accelerometers and gyroscopes on mobile devices, test, and apply this data to manipulate or change the virtual world. The ultimate goal is to use the test results to create a functional package and integrate it into the XPlan project.
> 
> ## Functions Used
> Primarily using Unity's Input.gyro and Input.acceleration.
> 
> ## Issues Encountered and Solutions
> None
>
> ## Log
> 2024.7.18  
> The accelerometer not only detects the device's movement but is also affected by gravity. To obtain pure movement acceleration, I had to spend some time using unfamiliar quaternion calculations.
>
> 
> 2024.7.19  
> Although the accelerometer can sense changes in the phone's acceleration, its accuracy needs improvement. It cannot accurately simulate the phone's movement in real-world space. Therefore, attempts will be stopped and AR Foundation will be used instead.
> 
> 
> ## Additional Information
> None
> 
> ## References
> 1. [Unity - how to make a player controller with gyroscope and accelerometer](https://www.youtube.com/watch?v=jvwX5WthM2o)
> 2. [Unity Gyroscope tutorial | use phones Gyroscope as Input](https://www.youtube.com/watch?v=V_fJnhw8p3g)