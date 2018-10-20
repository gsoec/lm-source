.class public Lcom/igg/sdk/battle/IGGBattleRecordFacade;
.super Ljava/lang/Object;
.source "IGGBattleRecordFacade.java"


# static fields
.field private static TAG:Ljava/lang/String;


# instance fields
.field private gameId:Ljava/lang/String;

.field private storage:Lcom/igg/sdk/IGGStorage;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 19
    const-string v0, "IGGBattleRecordFacade"

    sput-object v0, Lcom/igg/sdk/battle/IGGBattleRecordFacade;->TAG:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 2

    .prologue
    .line 35
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 36
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordFacade;->gameId:Ljava/lang/String;

    .line 37
    new-instance v0, Lcom/igg/sdk/IGGStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getDataCenter()Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/igg/sdk/IGGStorage;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    iput-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordFacade;->storage:Lcom/igg/sdk/IGGStorage;

    .line 38
    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Lcom/igg/sdk/IGGStorage;)V
    .locals 0
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "storage"    # Lcom/igg/sdk/IGGStorage;

    .prologue
    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 31
    iput-object p1, p0, Lcom/igg/sdk/battle/IGGBattleRecordFacade;->gameId:Ljava/lang/String;

    .line 32
    iput-object p2, p0, Lcom/igg/sdk/battle/IGGBattleRecordFacade;->storage:Lcom/igg/sdk/IGGStorage;

    .line 33
    return-void
.end method


# virtual methods
.method public download(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;)V
    .locals 3
    .param p1, "uniqueName"    # Ljava/lang/String;
    .param p2, "targetDirectory"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;

    .prologue
    .line 70
    new-instance v0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;

    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordFacade;->gameId:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/sdk/battle/IGGBattleRecordFacade;->storage:Lcom/igg/sdk/IGGStorage;

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;-><init>(Ljava/lang/String;Lcom/igg/sdk/IGGStorage;)V

    .line 71
    .local v0, "downloader":Lcom/igg/sdk/battle/IGGBattleRecordDownloader;
    invoke-virtual {v0, p1, p2, p3}, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->download(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;)V

    .line 72
    return-void
.end method

.method public upload(Lcom/igg/sdk/battle/IGGBattleRecord;ILcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V
    .locals 4
    .param p1, "recordFile"    # Lcom/igg/sdk/battle/IGGBattleRecord;
    .param p2, "retryTimes"    # I
    .param p3, "listener"    # Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    .prologue
    .line 52
    new-instance v1, Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    iget-object v2, p0, Lcom/igg/sdk/battle/IGGBattleRecordFacade;->gameId:Ljava/lang/String;

    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordFacade;->storage:Lcom/igg/sdk/IGGStorage;

    invoke-direct {v1, v2, v3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;-><init>(Ljava/lang/String;Lcom/igg/sdk/IGGStorage;)V

    .line 54
    .local v1, "uploader":Lcom/igg/sdk/battle/IGGBattleRecordUploader;
    :try_start_0
    invoke-virtual {v1, p2}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->setRetryTimes(I)V

    .line 55
    invoke-virtual {v1, p1, p3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->upload(Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 60
    :goto_0
    return-void

    .line 56
    :catch_0
    move-exception v0

    .line 57
    .local v0, "e":Ljava/lang/Exception;
    const/16 v2, 0x67

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v3

    invoke-interface {p3, p1, v2, v3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;->onUplaoadFailed(Lcom/igg/sdk/battle/IGGBattleRecord;ILjava/lang/String;)V

    .line 58
    sget-object v2, Lcom/igg/sdk/battle/IGGBattleRecordFacade;->TAG:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method
