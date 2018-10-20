.class public Lcom/igg/sdk/battle/IGGBattleRecordDownloader;
.super Ljava/lang/Object;
.source "IGGBattleRecordDownloader.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;
    }
.end annotation


# static fields
.field private static TAG:Ljava/lang/String;


# instance fields
.field private gameId:Ljava/lang/String;

.field private httpUrl:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 19
    const-string v0, "IGGBattleRecordDownloader"

    sput-object v0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->TAG:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Lcom/igg/sdk/IGGStorage;)V
    .locals 1
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "storage"    # Lcom/igg/sdk/IGGStorage;

    .prologue
    .line 57
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 58
    const-string v0, "pull.php"

    invoke-virtual {p2, v0}, Lcom/igg/sdk/IGGStorage;->getAPIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->httpUrl:Ljava/lang/String;

    .line 59
    iput-object p1, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->gameId:Ljava/lang/String;

    .line 60
    return-void
.end method


# virtual methods
.method public download(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;)V
    .locals 3
    .param p1, "uniqueName"    # Ljava/lang/String;
    .param p2, "targetDirectory"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;

    .prologue
    .line 72
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->httpUrl:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "?video="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "&g_id="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->gameId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->httpUrl:Ljava/lang/String;

    .line 73
    sget-object v0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->TAG:Ljava/lang/String;

    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->httpUrl:Ljava/lang/String;

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 74
    new-instance v0, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->httpUrl:Ljava/lang/String;

    new-instance v2, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;

    invoke-direct {v2, p0, p3, p1}, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;-><init>(Lcom/igg/sdk/battle/IGGBattleRecordDownloader;Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;Ljava/lang/String;)V

    invoke-virtual {v0, v1, p1, p2, v2}, Lcom/igg/sdk/service/IGGService;->DownloadFileRequest(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGService$DownloadRequestListener;)V

    .line 90
    return-void
.end method
