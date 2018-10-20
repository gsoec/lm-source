.class public Lcom/igg/android/lordsmobile_cn/wxapi/WXEntryActivity;
.super Landroid/app/Activity;
.source "WXEntryActivity.java"

# interfaces
.implements Lcom/tencent/mm/sdk/openapi/IWXAPIEventHandler;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 17
    invoke-direct {p0}, Landroid/app/Activity;-><init>()V

    return-void
.end method


# virtual methods
.method protected onCreate(Landroid/os/Bundle;)V
    .locals 3
    .param p1, "savedInstanceState"    # Landroid/os/Bundle;

    .prologue
    .line 21
    const-string v1, "WXEntryActivity"

    const-string v2, "WXEntryActivity onCreate"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 22
    invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V

    .line 24
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CreateWXAPI()Lcom/tencent/mm/sdk/openapi/IWXAPI;

    move-result-object v0

    .line 26
    .local v0, "mWeixinAPI":Lcom/tencent/mm/sdk/openapi/IWXAPI;
    invoke-virtual {p0}, Lcom/igg/android/lordsmobile_cn/wxapi/WXEntryActivity;->getIntent()Landroid/content/Intent;

    move-result-object v1

    invoke-interface {v0, v1, p0}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->handleIntent(Landroid/content/Intent;Lcom/tencent/mm/sdk/openapi/IWXAPIEventHandler;)Z

    .line 27
    return-void
.end method

.method protected onNewIntent(Landroid/content/Intent;)V
    .locals 3
    .param p1, "intent"    # Landroid/content/Intent;

    .prologue
    .line 32
    const-string v1, "WXEntryActivity"

    const-string v2, "onNewIntent"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 33
    invoke-super {p0, p1}, Landroid/app/Activity;->onNewIntent(Landroid/content/Intent;)V

    .line 35
    invoke-virtual {p0, p1}, Lcom/igg/android/lordsmobile_cn/wxapi/WXEntryActivity;->setIntent(Landroid/content/Intent;)V

    .line 36
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CreateWXAPI()Lcom/tencent/mm/sdk/openapi/IWXAPI;

    move-result-object v0

    .line 38
    .local v0, "mWeixinAPI":Lcom/tencent/mm/sdk/openapi/IWXAPI;
    invoke-interface {v0, p1, p0}, Lcom/tencent/mm/sdk/openapi/IWXAPI;->handleIntent(Landroid/content/Intent;Lcom/tencent/mm/sdk/openapi/IWXAPIEventHandler;)Z

    .line 39
    return-void
.end method

.method public onReq(Lcom/tencent/mm/sdk/modelbase/BaseReq;)V
    .locals 3
    .param p1, "req"    # Lcom/tencent/mm/sdk/modelbase/BaseReq;

    .prologue
    .line 44
    const-string v0, "WXEntryActivity"

    const-string v1, "onReq"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 45
    invoke-virtual {p1}, Lcom/tencent/mm/sdk/modelbase/BaseReq;->getType()I

    move-result v0

    packed-switch v0, :pswitch_data_0

    .line 56
    :goto_0
    return-void

    .line 48
    :pswitch_0
    const-string v0, "WXEntryActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onReq:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p1}, Lcom/tencent/mm/sdk/modelbase/BaseReq;->getType()I

    move-result v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 51
    :pswitch_1
    const-string v0, "WXEntryActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onReq:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p1}, Lcom/tencent/mm/sdk/modelbase/BaseReq;->getType()I

    move-result v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 45
    nop

    :pswitch_data_0
    .packed-switch 0x3
        :pswitch_0
        :pswitch_1
    .end packed-switch
.end method

.method public onResp(Lcom/tencent/mm/sdk/modelbase/BaseResp;)V
    .locals 4
    .param p1, "resp"    # Lcom/tencent/mm/sdk/modelbase/BaseResp;

    .prologue
    .line 62
    const-string v1, "WXEntryActivity"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "onResp:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    iget v3, p1, Lcom/tencent/mm/sdk/modelbase/BaseResp;->errCode:I

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 63
    iget v1, p1, Lcom/tencent/mm/sdk/modelbase/BaseResp;->errCode:I

    packed-switch v1, :pswitch_data_0

    .line 80
    :goto_0
    :pswitch_0
    invoke-virtual {p0}, Lcom/igg/android/lordsmobile_cn/wxapi/WXEntryActivity;->finish()V

    .line 81
    return-void

    :pswitch_1
    move-object v1, p1

    .line 66
    check-cast v1, Lcom/tencent/mm/sdk/modelmsg/SendAuth$Resp;

    iget-object v0, v1, Lcom/tencent/mm/sdk/modelmsg/SendAuth$Resp;->code:Ljava/lang/String;

    .line 67
    .local v0, "code":Ljava/lang/String;
    const-string v1, "WXEntryActivity"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "code: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 68
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v1

    invoke-virtual {v1, p1}, Lcom/igg/iggsdkbusiness/WeChatHelper;->SetResp(Lcom/tencent/mm/sdk/modelbase/BaseResp;)V

    goto :goto_0

    .line 63
    :pswitch_data_0
    .packed-switch -0x4
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_1
    .end packed-switch
.end method
