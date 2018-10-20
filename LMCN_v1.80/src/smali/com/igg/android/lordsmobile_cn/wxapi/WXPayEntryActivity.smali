.class public Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;
.super Landroid/app/Activity;
.source "WXPayEntryActivity.java"

# interfaces
.implements Lcom/tencent/mm/sdk/openapi/IWXAPIEventHandler;


# static fields
.field private static final TAG:Ljava/lang/String; = "MicroMsg.SDKSample.WXPayEntryActivity"


# instance fields
.field public WeChatPatCallBackCencel:Ljava/lang/String;

.field public WeChatPayCallBackFailed:Ljava/lang/String;

.field public WeChatPayCallBackSuccessful:Ljava/lang/String;

.field private api:Lcom/tencent/mm/sdk/openapi/IWXAPI;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 26
    invoke-direct {p0}, Landroid/app/Activity;-><init>()V

    .line 28
    const-string v0, "WeChatPayCallBackFailed"

    iput-object v0, p0, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->WeChatPayCallBackFailed:Ljava/lang/String;

    .line 29
    const-string v0, "WeChatPayCallBackSuccessful"

    iput-object v0, p0, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->WeChatPayCallBackSuccessful:Ljava/lang/String;

    .line 30
    const-string v0, "WeChatPatCallBackCencel"

    iput-object v0, p0, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->WeChatPatCallBackCencel:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 36
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 37
    return-void
.end method

.method protected onCreate(Landroid/os/Bundle;)V
    .locals 2
    .param p1, "savedInstanceState"    # Landroid/os/Bundle;

    .prologue
    .line 41
    invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V

    .line 43
    const-string v0, "WeChatPay"

    const-string v1, "WXPayEntryActivity.onCreate "

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 44
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CreateWXAPI()Lcom/tencent/mm/sdk/openapi/IWXAPI;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->api:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    .line 45
    iget-object v0, p0, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->api:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    invoke-virtual {p0}, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->getIntent()Landroid/content/Intent;

    move-result-object v1

    invoke-interface {v0, v1, p0}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->handleIntent(Landroid/content/Intent;Lcom/tencent/mm/sdk/openapi/IWXAPIEventHandler;)Z

    .line 46
    return-void
.end method

.method protected onNewIntent(Landroid/content/Intent;)V
    .locals 1
    .param p1, "intent"    # Landroid/content/Intent;

    .prologue
    .line 50
    invoke-super {p0, p1}, Landroid/app/Activity;->onNewIntent(Landroid/content/Intent;)V

    .line 51
    invoke-virtual {p0, p1}, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->setIntent(Landroid/content/Intent;)V

    .line 52
    iget-object v0, p0, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->api:Lcom/tencent/mm/sdk/openapi/IWXAPI;

    invoke-interface {v0, p1, p0}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->handleIntent(Landroid/content/Intent;Lcom/tencent/mm/sdk/openapi/IWXAPIEventHandler;)Z

    .line 53
    return-void
.end method

.method public onReq(Lcom/tencent/mm/sdk/modelbase/BaseReq;)V
    .locals 0
    .param p1, "req"    # Lcom/tencent/mm/sdk/modelbase/BaseReq;

    .prologue
    .line 57
    return-void
.end method

.method public onResp(Lcom/tencent/mm/sdk/modelbase/BaseResp;)V
    .locals 3
    .param p1, "resp"    # Lcom/tencent/mm/sdk/modelbase/BaseResp;

    .prologue
    .line 62
    const-string v0, "MicroMsg.SDKSample.WXPayEntryActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onPayFinish, errCode = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget v2, p1, Lcom/tencent/mm/sdk/modelbase/BaseResp;->errCode:I

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 63
    const-string v0, "WeChatPay"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onPayFinish, errCode = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget v2, p1, Lcom/tencent/mm/sdk/modelbase/BaseResp;->errCode:I

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 68
    invoke-virtual {p1}, Lcom/tencent/mm/sdk/modelbase/BaseResp;->getType()I

    move-result v0

    const/4 v1, 0x5

    if-ne v0, v1, :cond_0

    .line 70
    iget v0, p1, Lcom/tencent/mm/sdk/modelbase/BaseResp;->errCode:I

    packed-switch v0, :pswitch_data_0

    .line 83
    :cond_0
    :goto_0
    invoke-virtual {p0}, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->finish()V

    .line 99
    return-void

    .line 73
    :pswitch_0
    iget-object v0, p0, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->WeChatPayCallBackSuccessful:Ljava/lang/String;

    const-string v1, ""

    invoke-virtual {p0, v0, v1}, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 76
    :pswitch_1
    iget-object v0, p0, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->WeChatPayCallBackFailed:Ljava/lang/String;

    const-string v1, ""

    invoke-virtual {p0, v0, v1}, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 79
    :pswitch_2
    iget-object v0, p0, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->WeChatPatCallBackCencel:Ljava/lang/String;

    const-string v1, ""

    invoke-virtual {p0, v0, v1}, Lcom/igg/android/lordsmobile_cn/wxapi/WXPayEntryActivity;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 70
    :pswitch_data_0
    .packed-switch -0x2
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method
