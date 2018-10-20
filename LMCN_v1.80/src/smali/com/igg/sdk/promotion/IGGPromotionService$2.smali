.class Lcom/igg/sdk/promotion/IGGPromotionService$2;
.super Ljava/lang/Object;
.source "IGGPromotionService.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/promotion/IGGPromotionService;->initialize(Landroid/content/Context;Lcom/igg/sdk/promotion/listener/IGGInitializationListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/promotion/IGGPromotionService;

.field final synthetic val$context:Landroid/content/Context;

.field final synthetic val$handler:Landroid/os/Handler;


# direct methods
.method constructor <init>(Lcom/igg/sdk/promotion/IGGPromotionService;Landroid/content/Context;Landroid/os/Handler;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/promotion/IGGPromotionService;

    .prologue
    .line 93
    iput-object p1, p0, Lcom/igg/sdk/promotion/IGGPromotionService$2;->this$0:Lcom/igg/sdk/promotion/IGGPromotionService;

    iput-object p2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$2;->val$context:Landroid/content/Context;

    iput-object p3, p0, Lcom/igg/sdk/promotion/IGGPromotionService$2;->val$handler:Landroid/os/Handler;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 6

    .prologue
    .line 96
    const/4 v2, 0x0

    .line 99
    .local v2, "exception":Ljava/lang/Exception;
    :try_start_0
    iget-object v4, p0, Lcom/igg/sdk/promotion/IGGPromotionService$2;->val$context:Landroid/content/Context;

    invoke-static {v4}, Lcom/google/android/gms/ads/identifier/AdvertisingIdClient;->getAdvertisingIdInfo(Landroid/content/Context;)Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;

    move-result-object v4

    invoke-virtual {v4}, Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;->getId()Ljava/lang/String;

    move-result-object v0

    .line 101
    .local v0, "adId":Ljava/lang/String;
    new-instance v3, Landroid/os/Message;

    invoke-direct {v3}, Landroid/os/Message;-><init>()V

    .line 102
    .local v3, "msg":Landroid/os/Message;
    const/4 v4, 0x0

    iput v4, v3, Landroid/os/Message;->what:I

    .line 103
    iput-object v0, v3, Landroid/os/Message;->obj:Ljava/lang/Object;

    .line 104
    iget-object v4, p0, Lcom/igg/sdk/promotion/IGGPromotionService$2;->val$handler:Landroid/os/Handler;

    invoke-virtual {v4, v3}, Landroid/os/Handler;->sendMessage(Landroid/os/Message;)Z
    :try_end_0
    .catch Ljava/lang/IllegalStateException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Lcom/google/android/gms/common/GooglePlayServicesRepairableException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_2
    .catch Lcom/google/android/gms/common/GooglePlayServicesNotAvailableException; {:try_start_0 .. :try_end_0} :catch_3

    .line 116
    .end local v0    # "adId":Ljava/lang/String;
    .end local v3    # "msg":Landroid/os/Message;
    :goto_0
    if-eqz v2, :cond_0

    .line 117
    iget-object v4, p0, Lcom/igg/sdk/promotion/IGGPromotionService$2;->val$handler:Landroid/os/Handler;

    const/4 v5, 0x1

    invoke-virtual {v4, v5}, Landroid/os/Handler;->sendEmptyMessage(I)Z

    .line 118
    const-string v4, "IGGPromotionService"

    const-string v5, "failed to get adId"

    invoke-static {v4, v5}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 119
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    .line 121
    :cond_0
    return-void

    .line 106
    :catch_0
    move-exception v1

    .line 107
    .local v1, "e1":Ljava/lang/IllegalStateException;
    move-object v2, v1

    .line 114
    goto :goto_0

    .line 108
    .end local v1    # "e1":Ljava/lang/IllegalStateException;
    :catch_1
    move-exception v1

    .line 109
    .local v1, "e1":Lcom/google/android/gms/common/GooglePlayServicesRepairableException;
    move-object v2, v1

    .line 114
    goto :goto_0

    .line 110
    .end local v1    # "e1":Lcom/google/android/gms/common/GooglePlayServicesRepairableException;
    :catch_2
    move-exception v1

    .line 111
    .local v1, "e1":Ljava/io/IOException;
    move-object v2, v1

    .line 114
    goto :goto_0

    .line 112
    .end local v1    # "e1":Ljava/io/IOException;
    :catch_3
    move-exception v1

    .line 113
    .local v1, "e1":Lcom/google/android/gms/common/GooglePlayServicesNotAvailableException;
    move-object v2, v1

    goto :goto_0
.end method
