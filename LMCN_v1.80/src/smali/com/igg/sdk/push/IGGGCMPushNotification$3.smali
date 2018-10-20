.class Lcom/igg/sdk/push/IGGGCMPushNotification$3;
.super Ljava/lang/Object;
.source "IGGGCMPushNotification.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/push/IGGGCMPushNotification;->uninitialize()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;


# direct methods
.method constructor <init>(Lcom/igg/sdk/push/IGGGCMPushNotification;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/push/IGGGCMPushNotification;

    .prologue
    .line 269
    iput-object p1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$3;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onDeviceRegistrationFinished(Lcom/igg/sdk/error/IGGError;)V
    .locals 2
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;

    .prologue
    .line 274
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 275
    const-string v0, "IGGPushNotification"

    const-string v1, "Gcm uninitialize notification server successfully"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 280
    :goto_0
    return-void

    .line 277
    :cond_0
    const-string v0, "IGGPushNotification"

    const-string v1, "Gcm uninitialize notification server  failed"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method
