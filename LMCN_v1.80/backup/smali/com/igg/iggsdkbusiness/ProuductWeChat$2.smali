.class Lcom/igg/iggsdkbusiness/ProuductWeChat$2;
.super Ljava/lang/Object;
.source "ProuductWeChat.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/ProuductWeChat;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/ProuductWeChat;

    .prologue
    .line 252
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentLoadDataFinished(Lcom/igg/sdk/error/IGGError;ZLjava/lang/String;)V
    .locals 7
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "success"    # Z
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 257
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v4

    if-eqz v4, :cond_0

    .line 258
    const-string v4, "WeChatPay"

    const-string v5, "no network"

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 259
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPayCallBackFailed:Ljava/lang/String;

    const-string v6, ""

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 313
    :goto_0
    return-void

    .line 264
    :cond_0
    if-eqz p3, :cond_4

    :try_start_0
    const-string v4, ""

    invoke-virtual {p3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_4

    .line 265
    const-string v4, "WeChatPayDemoActivity"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "responseString:"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 267
    new-instance v2, Lorg/json/JSONObject;

    invoke-direct {v2, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 268
    .local v2, "json":Lorg/json/JSONObject;
    if-eqz p2, :cond_3

    .line 269
    new-instance v3, Lcom/tencent/mm/sdk/modelpay/PayReq;

    invoke-direct {v3}, Lcom/tencent/mm/sdk/modelpay/PayReq;-><init>()V

    .line 270
    .local v3, "req":Lcom/tencent/mm/sdk/modelpay/PayReq;
    const-string v4, "wxe1abdb4fccef2ae5"

    iput-object v4, v3, Lcom/tencent/mm/sdk/modelpay/PayReq;->appId:Ljava/lang/String;

    .line 271
    const-string v4, "prepayid"

    invoke-virtual {v2, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v3, Lcom/tencent/mm/sdk/modelpay/PayReq;->prepayId:Ljava/lang/String;

    .line 272
    const-string v4, "sign"

    invoke-virtual {v2, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v3, Lcom/tencent/mm/sdk/modelpay/PayReq;->sign:Ljava/lang/String;

    .line 273
    const-string v4, "partnerid"

    invoke-virtual {v2, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v3, Lcom/tencent/mm/sdk/modelpay/PayReq;->partnerId:Ljava/lang/String;

    .line 274
    const-string v4, "noncestr"

    invoke-virtual {v2, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v3, Lcom/tencent/mm/sdk/modelpay/PayReq;->nonceStr:Ljava/lang/String;

    .line 275
    const-string v4, "package"

    invoke-virtual {v2, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v3, Lcom/tencent/mm/sdk/modelpay/PayReq;->packageValue:Ljava/lang/String;

    .line 276
    const-string v4, "timestamp"

    invoke-virtual {v2, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v3, Lcom/tencent/mm/sdk/modelpay/PayReq;->timeStamp:Ljava/lang/String;

    .line 281
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CreateWXAPI()Lcom/tencent/mm/sdk/openapi/IWXAPI;

    move-result-object v0

    .line 283
    .local v0, "api":Lcom/tencent/mm/sdk/openapi/IWXAPI;
    invoke-interface {v0}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->isWXAppInstalled()Z

    move-result v4

    if-nez v4, :cond_1

    .line 284
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPayCallBackFailed:Ljava/lang/String;

    const-string v6, ""

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 309
    .end local v0    # "api":Lcom/tencent/mm/sdk/openapi/IWXAPI;
    .end local v2    # "json":Lorg/json/JSONObject;
    .end local v3    # "req":Lcom/tencent/mm/sdk/modelpay/PayReq;
    :catch_0
    move-exception v1

    .line 310
    .local v1, "e":Ljava/lang/Exception;
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPayCallBackFailed:Ljava/lang/String;

    const-string v6, ""

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 311
    const-string v4, "WeChatPay"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "\u5f02\u5e38\uff1a"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v1}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 288
    .end local v1    # "e":Ljava/lang/Exception;
    .restart local v0    # "api":Lcom/tencent/mm/sdk/openapi/IWXAPI;
    .restart local v2    # "json":Lorg/json/JSONObject;
    .restart local v3    # "req":Lcom/tencent/mm/sdk/modelpay/PayReq;
    :cond_1
    :try_start_1
    invoke-interface {v0}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->isWXAppSupportAPI()Z

    move-result v4

    if-eqz v4, :cond_2

    .line 290
    const-string v4, "wxe1abdb4fccef2ae5"

    invoke-interface {v0, v4}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->registerApp(Ljava/lang/String;)Z

    .line 291
    invoke-interface {v0, v3}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->sendReq(Lcom/tencent/mm/sdk/modelbase/BaseReq;)Z

    goto/16 :goto_0

    .line 293
    :cond_2
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPayCallBackFailed:Ljava/lang/String;

    const-string v6, ""

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 294
    const-string v4, "WeChatPay"

    const-string v5, "isWXAppSupportAPI false"

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 299
    .end local v0    # "api":Lcom/tencent/mm/sdk/openapi/IWXAPI;
    .end local v3    # "req":Lcom/tencent/mm/sdk/modelpay/PayReq;
    :cond_3
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPayCallBackFailed:Ljava/lang/String;

    const-string v6, ""

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 300
    const-string v4, "WeChatPay"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "\u8fd4\u56de\u9519\u8bef\u7801"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "code"

    invoke-virtual {v2, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 304
    .end local v2    # "json":Lorg/json/JSONObject;
    :cond_4
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPayCallBackFailed:Ljava/lang/String;

    const-string v6, ""

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 305
    const-string v4, "WeChatPay"

    const-string v5, "\u670d\u52a1\u5668\u8bf7\u6c42\u9519\u8bef"

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
