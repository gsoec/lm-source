.class public Lcom/igg/iggsdkbusiness/WeChatHelper;
.super Ljava/lang/Object;
.source "WeChatHelper.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;
    }
.end annotation


# static fields
.field public static final APP_ID:Ljava/lang/String; = "wxe1abdb4fccef2ae5"

.field public static BindNameTag:Ljava/lang/String;

.field private static instance:Lcom/igg/iggsdkbusiness/WeChatHelper;


# instance fields
.field public BindWeChatCallBackFailed:Ljava/lang/String;

.field public BindWeChatCallBackSuccessful:Ljava/lang/String;

.field public WeChatLoginCallBackFailed:Ljava/lang/String;

.field public WechatLoginCallBackSuccessful:Ljava/lang/String;

.field private bIsIwxapiCreated:Z

.field private mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

.field private resp:Lcom/tencent/mm/sdk/modelbase/BaseResp;

.field private weChatCode:Ljava/lang/String;

.field private weChatLoginListener:Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 49
    const-string v0, "wechat_bind_name"

    sput-object v0, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindNameTag:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 2

    .prologue
    const/4 v1, 0x0

    .line 41
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 45
    const-string v0, "WeChatLoginCallBackFailed"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->WeChatLoginCallBackFailed:Ljava/lang/String;

    .line 46
    const-string v0, "WechatLoginCallBackSuccessful"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->WechatLoginCallBackSuccessful:Ljava/lang/String;

    .line 47
    const-string v0, "BindWeChatCallBackFailed"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindWeChatCallBackFailed:Ljava/lang/String;

    .line 48
    const-string v0, "BindWeChatCallBackSuccessful"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindWeChatCallBackSuccessful:Ljava/lang/String;

    .line 61
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->bIsIwxapiCreated:Z

    .line 62
    iput-object v1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    .line 63
    iput-object v1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->resp:Lcom/tencent/mm/sdk/modelbase/BaseResp;

    return-void
.end method

.method private getExpireTime()Ljava/lang/String;
    .locals 8

    .prologue
    .line 330
    new-instance v0, Ljava/text/SimpleDateFormat;

    const-string v1, "yyyy-MM-dd HH:mm:ss"

    sget-object v2, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v0, v1, v2}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    .line 331
    .local v0, "df":Ljava/text/SimpleDateFormat;
    new-instance v1, Ljava/util/Date;

    invoke-direct {v1}, Ljava/util/Date;-><init>()V

    invoke-virtual {v1}, Ljava/util/Date;->getTime()J

    move-result-wide v2

    sget v1, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    int-to-long v4, v1

    const-wide/16 v6, 0x3e8

    mul-long/2addr v4, v6

    add-long/2addr v2, v4

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/text/SimpleDateFormat;->format(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    return-object v1
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;
    .locals 1

    .prologue
    .line 68
    sget-object v0, Lcom/igg/iggsdkbusiness/WeChatHelper;->instance:Lcom/igg/iggsdkbusiness/WeChatHelper;

    if-nez v0, :cond_0

    .line 69
    new-instance v0, Lcom/igg/iggsdkbusiness/WeChatHelper;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/WeChatHelper;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/WeChatHelper;->instance:Lcom/igg/iggsdkbusiness/WeChatHelper;

    .line 71
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/WeChatHelper;->instance:Lcom/igg/iggsdkbusiness/WeChatHelper;

    return-object v0
.end method


# virtual methods
.method public BindToWeChat()V
    .locals 2

    .prologue
    .line 155
    const-string v0, "WeChat"

    const-string v1, "BindToWeChat"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 156
    new-instance v0, Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    invoke-direct {v0, p0}, Lcom/igg/iggsdkbusiness/WeChatHelper$1;-><init>(Lcom/igg/iggsdkbusiness/WeChatHelper;)V

    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/WeChatHelper;->RegisterWeChat(Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;)V

    .line 213
    return-void
.end method

.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 76
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 77
    return-void
.end method

.method public CreateWXAPI()Lcom/tencent/mm/sdk/openapi/IWXAPI;
    .locals 3

    .prologue
    const/4 v2, 0x1

    .line 82
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    if-nez v0, :cond_0

    .line 84
    const-string v0, "WeChat"

    const-string v1, "CreateWXAPI"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 85
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    invoke-virtual {v0}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    const-string v1, "wxe1abdb4fccef2ae5"

    invoke-static {v0, v1, v2}, Lcom/tencent/mm/sdk/openapi/WXAPIFactory;->createWXAPI(Landroid/content/Context;Ljava/lang/String;Z)Lcom/tencent/mm/sdk/openapi/IWXAPI;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    .line 86
    iput-boolean v2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->bIsIwxapiCreated:Z

    .line 88
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    return-object v0
.end method

.method public LoginWeChat()V
    .locals 1

    .prologue
    .line 217
    new-instance v0, Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    invoke-direct {v0, p0}, Lcom/igg/iggsdkbusiness/WeChatHelper$2;-><init>(Lcom/igg/iggsdkbusiness/WeChatHelper;)V

    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/WeChatHelper;->RegisterWeChat(Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;)V

    .line 288
    return-void
.end method

.method RegisterWeChat(Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;)V
    .locals 5
    .param p1, "listener"    # Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;

    .prologue
    .line 102
    const-string v2, "WeChat"

    const-string v3, "RegisterWeChat"

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 103
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatLoginListener:Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;

    .line 104
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CreateWXAPI()Lcom/tencent/mm/sdk/openapi/IWXAPI;

    move-result-object v2

    iput-object v2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    .line 106
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    invoke-interface {v2}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->isWXAppInstalled()Z

    move-result v2

    if-nez v2, :cond_0

    .line 109
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatLoginListener:Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;

    invoke-interface {v2}, Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;->onUninstall()V

    .line 122
    :goto_0
    return-void

    .line 113
    :cond_0
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    invoke-interface {v2}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->unregisterApp()V

    .line 115
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    const-string v3, "wxe1abdb4fccef2ae5"

    invoke-interface {v2, v3}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->registerApp(Ljava/lang/String;)Z

    .line 117
    new-instance v1, Lcom/tencent/mm/sdk/modelmsg/SendAuth$Req;

    invoke-direct {v1}, Lcom/tencent/mm/sdk/modelmsg/SendAuth$Req;-><init>()V

    .line 118
    .local v1, "req":Lcom/tencent/mm/sdk/modelmsg/SendAuth$Req;
    const-string v2, "snsapi_userinfo"

    iput-object v2, v1, Lcom/tencent/mm/sdk/modelmsg/SendAuth$Req;->scope:Ljava/lang/String;

    .line 119
    const-string v2, "Lords Mobile WeChat Bind"

    iput-object v2, v1, Lcom/tencent/mm/sdk/modelmsg/SendAuth$Req;->state:Ljava/lang/String;

    .line 120
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    invoke-interface {v2, v1}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->sendReq(Lcom/tencent/mm/sdk/modelbase/BaseReq;)Z

    move-result v0

    .line 121
    .local v0, "bres":Z
    const-string v2, "WeChat"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "mWeixinAPI.sendReq(req) = "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public SetResp(Lcom/tencent/mm/sdk/modelbase/BaseResp;)V
    .locals 0
    .param p1, "baseResp"    # Lcom/tencent/mm/sdk/modelbase/BaseResp;

    .prologue
    .line 92
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->resp:Lcom/tencent/mm/sdk/modelbase/BaseResp;

    .line 93
    return-void
.end method

.method public isWXAppInstalled()Z
    .locals 1

    .prologue
    .line 96
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    if-nez v0, :cond_0

    .line 97
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CreateWXAPI()Lcom/tencent/mm/sdk/openapi/IWXAPI;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    .line 98
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    invoke-interface {v0}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->isWXAppInstalled()Z

    move-result v0

    return v0
.end method

.method public onResume()V
    .locals 3

    .prologue
    .line 141
    const-string v0, "WeChat"

    const-string v1, "onResume"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 143
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->resp:Lcom/tencent/mm/sdk/modelbase/BaseResp;

    if-eqz v0, :cond_1

    .line 144
    const-string v0, "WeChat"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "resp Type = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->resp:Lcom/tencent/mm/sdk/modelbase/BaseResp;

    invoke-virtual {v2}, Lcom/tencent/mm/sdk/modelbase/BaseResp;->getType()I

    move-result v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 147
    :goto_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->mWeixinAPI:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->resp:Lcom/tencent/mm/sdk/modelbase/BaseResp;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->resp:Lcom/tencent/mm/sdk/modelbase/BaseResp;

    .line 148
    invoke-virtual {v0}, Lcom/tencent/mm/sdk/modelbase/BaseResp;->getType()I

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 149
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->resp:Lcom/tencent/mm/sdk/modelbase/BaseResp;

    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/WeChatHelper;->onResumeLogin(Lcom/tencent/mm/sdk/modelbase/BaseResp;)V

    .line 150
    const/4 v0, 0x0

    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/WeChatHelper;->SetResp(Lcom/tencent/mm/sdk/modelbase/BaseResp;)V

    .line 152
    :cond_0
    return-void

    .line 146
    :cond_1
    const-string v0, "WeChat"

    const-string v1, "resp = null"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public onResumeLogin(Lcom/tencent/mm/sdk/modelbase/BaseResp;)V
    .locals 3
    .param p1, "resp"    # Lcom/tencent/mm/sdk/modelbase/BaseResp;

    .prologue
    .line 129
    const-string v0, "WeChat"

    const-string v1, "onResumeLogin"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 130
    check-cast p1, Lcom/tencent/mm/sdk/modelmsg/SendAuth$Resp;

    .end local p1    # "resp":Lcom/tencent/mm/sdk/modelbase/BaseResp;
    iget-object v0, p1, Lcom/tencent/mm/sdk/modelmsg/SendAuth$Resp;->code:Ljava/lang/String;

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatCode:Ljava/lang/String;

    .line 131
    const-string v0, "onResumeLogin"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "code: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatCode:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 132
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatCode:Ljava/lang/String;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatCode:Ljava/lang/String;

    const-string v1, ""

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 133
    const-string v0, "onResumeLogin"

    const-string v1, "code: onSuccess"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 134
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatLoginListener:Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatCode:Ljava/lang/String;

    invoke-interface {v0, v1}, Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;->onSuccess(Ljava/lang/String;)V

    .line 138
    :goto_0
    return-void

    .line 136
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatLoginListener:Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;

    invoke-interface {v0}, Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;->onError()V

    goto :goto_0
.end method

.method public weChatPayment(Lcom/igg/sdk/service/IGGPaymentService;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;)V
    .locals 12
    .param p1, "payInfo"    # Lcom/igg/sdk/service/IGGPaymentService;
    .param p2, "itemId"    # Ljava/lang/String;
    .param p3, "itemName"    # Ljava/lang/String;
    .param p4, "price"    # Ljava/lang/String;
    .param p5, "quantity"    # Ljava/lang/String;
    .param p6, "restriction"    # Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;
    .param p7, "listener"    # Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;
    .param p8, "amoutOfLimitListener"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;

    .prologue
    .line 306
    if-nez p6, :cond_0

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object/from16 v5, p4

    move-object/from16 v6, p5

    move-object/from16 v7, p7

    .line 307
    invoke-virtual/range {v1 .. v7}, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatPayment(Lcom/igg/sdk/service/IGGPaymentService;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V

    .line 328
    :goto_0
    return-void

    .line 310
    :cond_0
    invoke-static {p2}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v10

    .line 311
    .local v10, "id":I
    new-instance v11, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v1

    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v2

    move-object/from16 v0, p6

    invoke-direct {v11, v1, v2, v10, v0}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;-><init>(Ljava/lang/String;Ljava/lang/String;ILcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;)V

    .line 312
    .local v11, "processor":Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;
    new-instance v1, Lcom/igg/iggsdkbusiness/WeChatHelper$3;

    move-object v2, p0

    move-object/from16 v3, p8

    move-object v4, p1

    move-object v5, p2

    move-object v6, p3

    move-object/from16 v7, p4

    move-object/from16 v8, p5

    move-object/from16 v9, p7

    invoke-direct/range {v1 .. v9}, Lcom/igg/iggsdkbusiness/WeChatHelper$3;-><init>(Lcom/igg/iggsdkbusiness/WeChatHelper;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;Lcom/igg/sdk/service/IGGPaymentService;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V

    invoke-virtual {v11, v1}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->process(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V

    goto :goto_0
.end method

.method public weChatPayment(Lcom/igg/sdk/service/IGGPaymentService;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V
    .locals 7
    .param p1, "payInfo"    # Lcom/igg/sdk/service/IGGPaymentService;
    .param p2, "itemId"    # Ljava/lang/String;
    .param p3, "itemName"    # Ljava/lang/String;
    .param p4, "price"    # Ljava/lang/String;
    .param p5, "quantity"    # Ljava/lang/String;
    .param p6, "listener"    # Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;

    .prologue
    .line 300
    sget-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    move-object v0, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, p5

    move-object v6, p6

    invoke-virtual/range {v0 .. v6}, Lcom/igg/sdk/service/IGGPaymentService;->getWeChatOrder(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V

    .line 301
    return-void
.end method
