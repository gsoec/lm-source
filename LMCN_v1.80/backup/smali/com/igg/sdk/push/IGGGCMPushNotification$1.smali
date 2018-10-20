.class Lcom/igg/sdk/push/IGGGCMPushNotification$1;
.super Ljava/lang/Object;
.source "IGGGCMPushNotification.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/push/IGGGCMPushNotification;->gcmRegisterDevice(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

.field final synthetic val$IGGID:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/push/IGGGCMPushNotification;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/push/IGGGCMPushNotification;

    .prologue
    .line 154
    iput-object p1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$1;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    iput-object p2, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$1;->val$IGGID:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 8

    .prologue
    .line 158
    :try_start_0
    iget-object v4, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$1;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    invoke-static {v4}, Lcom/igg/sdk/push/IGGGCMPushNotification;->access$000(Lcom/igg/sdk/push/IGGGCMPushNotification;)Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    move-result-object v4

    if-nez v4, :cond_0

    .line 159
    const-string v4, "IGGPushNotification"

    const-string v5, "GoogleCloudMessaging Start Initialization"

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 160
    iget-object v4, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$1;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    iget-object v5, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$1;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    invoke-static {v5}, Lcom/igg/sdk/push/IGGGCMPushNotification;->access$100(Lcom/igg/sdk/push/IGGGCMPushNotification;)Landroid/content/Context;

    move-result-object v5

    invoke-static {v5}, Lcom/google/android/gms/gcm/GoogleCloudMessaging;->getInstance(Landroid/content/Context;)Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    move-result-object v5

    invoke-static {v4, v5}, Lcom/igg/sdk/push/IGGGCMPushNotification;->access$002(Lcom/igg/sdk/push/IGGGCMPushNotification;Lcom/google/android/gms/gcm/GoogleCloudMessaging;)Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    .line 163
    :cond_0
    const-string v4, "IGGPushNotification"

    const-string v5, "GoogleCloudMessaging Successful Initialization"

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 165
    iget-object v4, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$1;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    invoke-static {v4}, Lcom/igg/sdk/push/IGGGCMPushNotification;->access$000(Lcom/igg/sdk/push/IGGGCMPushNotification;)Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    move-result-object v4

    const/4 v5, 0x1

    new-array v5, v5, [Ljava/lang/String;

    const/4 v6, 0x0

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v7

    invoke-virtual {v7}, Lcom/igg/sdk/IGGSDK;->getGCMSenderId()Ljava/lang/String;

    move-result-object v7

    aput-object v7, v5, v6

    invoke-virtual {v4, v5}, Lcom/google/android/gms/gcm/GoogleCloudMessaging;->register([Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 166
    .local v3, "registrationId":Ljava/lang/String;
    const-string v4, "IGGPushNotification"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "Device registered, registration ID="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 168
    const-string v0, ""

    .line 169
    .local v0, "adId":Ljava/lang/String;
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v4

    invoke-static {v4}, Lcom/igg/util/DeviceUtil;->getAdvertisingIdInfo(Landroid/content/Context;)Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;

    move-result-object v2

    .line 170
    .local v2, "info":Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;
    if-eqz v2, :cond_1

    .line 171
    invoke-virtual {v2}, Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;->getId()Ljava/lang/String;

    move-result-object v0

    .line 175
    :cond_1
    iget-object v4, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$1;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    iget-object v5, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$1;->val$IGGID:Ljava/lang/String;

    invoke-virtual {v4, v3, v5, v0}, Lcom/igg/sdk/push/IGGGCMPushNotification;->showMsg(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_0

    .line 180
    .end local v0    # "adId":Ljava/lang/String;
    .end local v2    # "info":Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;
    .end local v3    # "registrationId":Ljava/lang/String;
    :goto_0
    return-void

    .line 176
    :catch_0
    move-exception v1

    .line 177
    .local v1, "ex":Ljava/io/IOException;
    const-string v4, "IGGPushNotification"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "gcmRegisterDevice Error :"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v1}, Ljava/io/IOException;->getMessage()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 178
    iget-object v4, p0, Lcom/igg/sdk/push/IGGGCMPushNotification$1;->this$0:Lcom/igg/sdk/push/IGGGCMPushNotification;

    invoke-virtual {v4}, Lcom/igg/sdk/push/IGGGCMPushNotification;->nofifyRegisterFailMessage()V

    goto :goto_0
.end method
