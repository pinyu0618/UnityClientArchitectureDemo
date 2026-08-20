[README.md](https://github.com/user-attachments/files/31255221/README.md)

# Unity Client Architecture Demo

## 專案說明

1. 此為一個 Unity Client 結合 MVP 和 Scene Controller 架構的 Demo 專案。
2. 以拔除核心功能，僅保留 Singleton Service 實例、場景初始化及跳轉部分。

## 系統介面
![image](https://hackmd.io/_uploads/BJesmENvMx.png)


## 架構圖 & 流程圖
* 類別圖
![UnityClientArchitectureDemo-類別圖](https://hackmd.io/_uploads/HylBb4EDMe.png)

* 架構流程圖
![UnityClientArchitectureDemo-系統流程圖](https://hackmd.io/_uploads/BJ-LZVEwzx.png)

## 資料夾

* Assets
    * DemoProject
        * Scenes：所有場景檔案
        * Scripts
            * Controller：Scene Controller、Singleton Service
            * Data：Interface、Struct、全域常數定義
            * Model：Basic Core、Factory、業務邏輯處理、資料讀寫
            * Presenter：功能流程控制器
            * View：UI 呈現與使用者互動
    * Resource：圖片資源、Prefab

## 安裝

* Unity 6000.5.6f1
* Visual Studio 2022以上

## 執行

1. 設置 File > Build Profiles > Scene List
![image](https://hackmd.io/_uploads/rkFMB-mPGl.png)
2. 執行任一 Scene：00_Init、01_Login、02_Home

