.class Lcom/igg/sdk/push/IGGGCMPushNotification$2;
.super Landroid/os/Handler;
.source "IGGGCMPushNotification.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/push/IGGGCMPushNotification;
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
    .line 187
    iput-object p1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$2;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    invoke-direct {p0}, Landroid/os/Handler;-><init>()V

    return-void
.end method


# virtual methods
.method public handleMessage(Landroid/os/Message;)V
    .locals 7
    .param p1, "msg"    # Landroid/os/Message;

    .prologue
    .line 190
    invoke-super {p0, p1}, Landroid/os/Handler;->handleMessage(Landroid/os/Message;)V

    .line 191
    iget v0, p1, Landroid/os/Message;->what:I

    packed-switch v0, :pswitch_data_0

    .line 222
    :goto_0
    return-void

    .line 194
    :pswitch_0
    iget-object v6, p1, Landroid/os/Message;->obj:Ljava/lang/Object;

    check-cast v6, Ljava/util/HashMap;

    .line 195
    .local v6, "hashMap":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    const-string v0, "registrationId"

    invoke-virtual {v6, v0}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 196
    .local v2, "registrationId":Ljava/lang/String;
    const-string v0, "iggId"

    invoke-virtual {v6, v0}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 197
    .local v3, "iggId":Ljava/lang/String;
    const-string v0, "adId"

    invoke-virtual {v6, v0}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/String;

    .line 198
    .local v4, "adId":Ljava/lang/String;
    const-string v0, "IGGPushNotification"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "registrationId :"

    invoke-virtual {v1, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 199
    new-instance v0, Lcom/igg/sdk/service/IGGMobileDeviceService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGMobileDeviceService;-><init>()V

    const-string v1, "3"

    new-instance v5, Lcom/igg/sdk/push/IGGGCMPushNotification$2$1;

    invoke-direct {v5, p0, v2}, Lcom/igg/sdk/push/IGGGCMPushNotification$2$1;-><init>(Lcom/igg/sdk/push/IGGGCMPushNotification$2;Ljava/lang/String;)V

    invoke-virtual/range {v0 .. v5}, Lcom/igg/sdk/service/IGGMobileDeviceService;->registerDevice(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;)V

    goto :goto_0

    .line 218
    .end local v2    # "registrationId":Ljava/lang/String;
    .end local v3    # "iggId":Ljava/lang/String;
    .end local v4    # "adId":Ljava/lang/String;
    .end local v6    # "hashMap":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    :pswitch_1
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$2;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    const-string v1, "From GCM Server: failed added device!"

    invoke-static {v0, v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->access$300(Lcom/igg/sdk/push/IGGGCMPushNotification;Ljava/lang/String;)V

    goto :goto_0

    .line 191
    nop

    :pswitch_data_0
    .packed-switch 0x2
        :pswitch_0
        :pswitch_1
    .end packed-switch
.end method
