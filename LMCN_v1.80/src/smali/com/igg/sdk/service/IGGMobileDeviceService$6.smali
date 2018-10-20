.class Lcom/igg/sdk/service/IGGMobileDeviceService$6;
.super Ljava/lang/Object;
.source "IGGMobileDeviceService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGMobileDeviceService;->markMessage(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGMobileDeviceService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGMobileDeviceService;Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGMobileDeviceService;

    .prologue
    .line 320
    iput-object p1, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$6;->this$0:Lcom/igg/sdk/service/IGGMobileDeviceService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$6;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 9
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 325
    :try_start_0
    const-string v6, "IGGMobileDeviceService"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "responseString: "

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 326
    new-instance v2, Lorg/json/JSONObject;

    invoke-direct {v2, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 327
    .local v2, "jsonObject":Lorg/json/JSONObject;
    const-string v6, "errCode"

    invoke-virtual {v2, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 328
    .local v1, "errCode":Ljava/lang/String;
    const-string v6, "0"

    invoke-virtual {v1, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_1

    .line 329
    const-string v6, "result"

    invoke-virtual {v2, v6}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v3

    .line 330
    .local v3, "resultObject":Lorg/json/JSONObject;
    const-string v6, "return"

    invoke-virtual {v3, v6}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v4

    .line 331
    .local v4, "returnObject":Lorg/json/JSONObject;
    const-string v6, "success"

    invoke-virtual {v4, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    .line 332
    .local v5, "success":Ljava/lang/String;
    const-string v6, "1"

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_0

    .line 333
    iget-object v6, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$6;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;

    const/4 v7, 0x1

    invoke-interface {v6, p1, v7}, Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;->onMessageMarkingFinished(Lcom/igg/sdk/error/IGGError;Z)V

    .line 343
    .end local v1    # "errCode":Ljava/lang/String;
    .end local v2    # "jsonObject":Lorg/json/JSONObject;
    .end local v3    # "resultObject":Lorg/json/JSONObject;
    .end local v4    # "returnObject":Lorg/json/JSONObject;
    .end local v5    # "success":Ljava/lang/String;
    :goto_0
    return-void

    .line 335
    .restart local v1    # "errCode":Ljava/lang/String;
    .restart local v2    # "jsonObject":Lorg/json/JSONObject;
    .restart local v3    # "resultObject":Lorg/json/JSONObject;
    .restart local v4    # "returnObject":Lorg/json/JSONObject;
    .restart local v5    # "success":Ljava/lang/String;
    :cond_0
    iget-object v6, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$6;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;

    const/4 v7, 0x0

    invoke-interface {v6, p1, v7}, Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;->onMessageMarkingFinished(Lcom/igg/sdk/error/IGGError;Z)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 340
    .end local v1    # "errCode":Ljava/lang/String;
    .end local v2    # "jsonObject":Lorg/json/JSONObject;
    .end local v3    # "resultObject":Lorg/json/JSONObject;
    .end local v4    # "returnObject":Lorg/json/JSONObject;
    .end local v5    # "success":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 341
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0

    .line 338
    .end local v0    # "e":Ljava/lang/Exception;
    .restart local v1    # "errCode":Ljava/lang/String;
    .restart local v2    # "jsonObject":Lorg/json/JSONObject;
    :cond_1
    :try_start_1
    iget-object v6, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$6;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;

    const/4 v7, 0x0

    invoke-interface {v6, p1, v7}, Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;->onMessageMarkingFinished(Lcom/igg/sdk/error/IGGError;Z)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method
