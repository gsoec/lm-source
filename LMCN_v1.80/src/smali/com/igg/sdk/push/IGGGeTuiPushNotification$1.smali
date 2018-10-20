.class Lcom/igg/sdk/push/IGGGeTuiPushNotification$1;
.super Ljava/lang/Object;
.source "IGGGeTuiPushNotification.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/push/IGGGeTuiPushNotification;->uninitialize()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/push/IGGGeTuiPushNotification;


# direct methods
.method constructor <init>(Lcom/igg/sdk/push/IGGGeTuiPushNotification;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/push/IGGGeTuiPushNotification;

    .prologue
    .line 83
    iput-object p1, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification$1;->this$0:Lcom/igg/sdk/push/IGGGeTuiPushNotification;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onDeviceRegistrationFinished(Lcom/igg/sdk/error/IGGError;)V
    .locals 2
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;

    .prologue
    .line 88
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 89
    const-string v0, "GeTuiPush"

    const-string v1, "GeTui uninitialize notification server successfully"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 94
    :goto_0
    return-void

    .line 91
    :cond_0
    const-string v0, "GeTuiPush"

    const-string v1, "GeTui uninitialize notification server  failed"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method
