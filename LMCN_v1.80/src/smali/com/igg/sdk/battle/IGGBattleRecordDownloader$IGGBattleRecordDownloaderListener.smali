.class public interface abstract Lcom/igg/sdk/battle/IGGBattleRecordDownloader$IGGBattleRecordDownloaderListener;
.super Ljava/lang/Object;
.source "IGGBattleRecordDownloader.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/battle/IGGBattleRecordDownloader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "IGGBattleRecordDownloaderListener"
.end annotation


# virtual methods
.method public abstract onDownloadFailed(Ljava/lang/String;ILjava/lang/String;)V
.end method

.method public abstract onDownloadFinished(Lcom/igg/sdk/battle/IGGBattleRecord;)V
.end method
