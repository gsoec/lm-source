.class Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;
.super Ljava/lang/Object;
.source "IGGBattleRecordDownloader.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$DownloadRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/battle/IGGBattleRecordDownloader;->download(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/battle/IGGBattleRecordDownloader;

.field final synthetic val$listener:Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;

.field final synthetic val$uniqueName:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/battle/IGGBattleRecordDownloader;Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/battle/IGGBattleRecordDownloader;

    .prologue
    .line 74
    iput-object p1, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordDownloader;

    iput-object p2, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;

    iput-object p3, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;->val$uniqueName:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onDownloadRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/io/File;)V
    .locals 4
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseString"    # Ljava/lang/String;
    .param p3, "file"    # Ljava/io/File;

    .prologue
    .line 78
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 79
    iget-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;

    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;->val$uniqueName:Ljava/lang/String;

    const/16 v2, 0x65

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getOriginal()Ljava/lang/Exception;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v3

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;->onDownloadFailed(Ljava/lang/String;ILjava/lang/String;)V

    .line 88
    :goto_0
    return-void

    .line 83
    :cond_0
    if-eqz p2, :cond_1

    const-string v0, "success"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 84
    iget-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;

    new-instance v1, Lcom/igg/sdk/battle/IGGBattleRecord;

    invoke-direct {v1, p3}, Lcom/igg/sdk/battle/IGGBattleRecord;-><init>(Ljava/io/File;)V

    invoke-interface {v0, v1}, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;->onDownloadFinished(Lcom/igg/sdk/battle/IGGBattleRecord;)V

    goto :goto_0

    .line 86
    :cond_1
    iget-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;

    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$1;->val$uniqueName:Ljava/lang/String;

    const/16 v2, 0x66

    invoke-interface {v0, v1, v2, p2}, Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;->onDownloadFailed(Ljava/lang/String;ILjava/lang/String;)V

    goto :goto_0
.end method
