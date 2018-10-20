.class Lcom/igg/sdk/push/IGGGCMPushNotification$2$1;
.super Ljava/lang/Object;
.source "IGGGCMPushNotification.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/push/IGGGCMPushNotification$2;->handleMessage(Landroid/os/Message;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/sdk/push/IGGGCMPushNotification$2;

.field final synthetic val$registrationId:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/push/IGGGCMPushNotification$2;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/sdk/push/IGGGCMPushNotification$2;

    .prologue
    .line 199
    iput-object p1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$2$1;->this$1:Lcom/igg/sdk/push/IGGGCMPushNotification$2;

    iput-object p2, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$2$1;->val$registrationId:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onDeviceRegistrationFinished(Lcom/igg/sdk/error/IGGError;)V
    .locals 2
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;

    .prologue
    .line 202
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 204
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$2$1;->this$1:Lcom/igg/sdk/push/IGGGCMPushNotification$2;

    iget-object v0, v0, Lcom/igg/sdk/push/IGGGCMPushNotification$2;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$2$1;->val$registrationId:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->access$200(Lcom/igg/sdk/push/IGGGCMPushNotification;Ljava/lang/String;)V

    .line 207
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$2$1;->this$1:Lcom/igg/sdk/push/IGGGCMPushNotification$2;

    iget-object v0, v0, Lcom/igg/sdk/push/IGGGCMPushNotification$2;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    const-string v1, "From GCM Server: successfully added device!"

    invoke-static {v0, v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->access$300(Lcom/igg/sdk/push/IGGGCMPushNotification;Ljava/lang/String;)V

    .line 212
    :goto_0
    return-void

    .line 210
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$2$1;->this$1:Lcom/igg/sdk/push/IGGGCMPushNotification$2;

    iget-object v0, v0, Lcom/igg/sdk/push/IGGGCMPushNotification$2;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    const-string v1, "From GCM Server: failed added device!"

    invoke-static {v0, v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->access$300(Lcom/igg/sdk/push/IGGGCMPushNotification;Ljava/lang/String;)V

    goto :goto_0
.end method
