.class final Lcom/igg/sdk/push/IGGGCMPushNotification$4;
.super Ljava/lang/Object;
.source "IGGGCMPushNotification.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/push/IGGGCMPushNotification;->onMessageRead(Ljava/lang/String;Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = null
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .prologue
    .line 350
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onMessageMarkingFinished(Lcom/igg/sdk/error/IGGError;Z)V
    .locals 2
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "success"    # Z

    .prologue
    .line 353
    if-eqz p2, :cond_0

    .line 354
    const-string v0, "IGGPushNotification"

    const-string v1, "onMessageRead success"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 358
    :goto_0
    return-void

    .line 356
    :cond_0
    const-string v0, "IGGPushNotification"

    const-string v1, "onMessageRead failed"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method
