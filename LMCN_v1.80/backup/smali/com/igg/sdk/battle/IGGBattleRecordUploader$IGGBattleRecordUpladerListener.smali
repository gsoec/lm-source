.class public interface abstract Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;
.super Ljava/lang/Object;
.source "IGGBattleRecordUploader.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/battle/IGGBattleRecordUploader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "IGGBattleRecordUpladerListener"
.end annotation


# virtual methods
.method public abstract onUplaoadFailed(Lcom/igg/sdk/battle/IGGBattleRecord;ILjava/lang/String;)V
.end method

.method public abstract onUploadFinished(Lcom/igg/sdk/battle/IGGBattleRecord;I)V
.end method
