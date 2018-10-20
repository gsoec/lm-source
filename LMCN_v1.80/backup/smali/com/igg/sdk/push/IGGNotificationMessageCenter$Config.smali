.class public Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;
.super Ljava/lang/Object;
.source "IGGNotificationMessageCenter.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/push/IGGNotificationMessageCenter;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Config"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 140
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public isCustomHandle(Landroid/content/Context;)Z
    .locals 4
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 143
    new-instance v0, Lcom/igg/sdk/push/IGGPushStorageService;

    invoke-direct {v0, p1}, Lcom/igg/sdk/push/IGGPushStorageService;-><init>(Landroid/content/Context;)V

    .line 144
    .local v0, "pushStorageService":Lcom/igg/sdk/push/IGGPushStorageService;
    const-string v1, "IGGNotificationCenter"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, " pushStorageService.isCustomHandleMessage"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v0}, Lcom/igg/sdk/push/IGGPushStorageService;->isCustomHandleMessage()Z

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 145
    invoke-virtual {v0}, Lcom/igg/sdk/push/IGGPushStorageService;->isCustomHandleMessage()Z

    move-result v1

    return v1
.end method

.method public setCustomHandle(Landroid/content/Context;Z)V
    .locals 1
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "customHandle"    # Z

    .prologue
    .line 149
    new-instance v0, Lcom/igg/sdk/push/IGGPushStorageService;

    invoke-direct {v0, p1}, Lcom/igg/sdk/push/IGGPushStorageService;-><init>(Landroid/content/Context;)V

    .line 150
    .local v0, "pushStorageService":Lcom/igg/sdk/push/IGGPushStorageService;
    invoke-virtual {v0, p2}, Lcom/igg/sdk/push/IGGPushStorageService;->setCustomHandleMessageFlag(Z)V

    .line 151
    return-void
.end method
