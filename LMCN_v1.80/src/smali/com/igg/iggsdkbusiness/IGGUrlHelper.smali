.class public Lcom/igg/iggsdkbusiness/IGGUrlHelper;
.super Ljava/lang/Object;
.source "IGGUrlHelper.java"


# static fields
.field private static instance:Lcom/igg/iggsdkbusiness/IGGUrlHelper;


# instance fields
.field FacebookLikeCallBack:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 14
    const-string v0, "FacebookLikeCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->FacebookLikeCallBack:Ljava/lang/String;

    return-void
.end method

.method private OpenUrl(Ljava/lang/String;)V
    .locals 3
    .param p1, "pUrl"    # Ljava/lang/String;

    .prologue
    .line 106
    move-object v1, p1

    .line 107
    .local v1, "url":Ljava/lang/String;
    new-instance v0, Landroid/content/Intent;

    const-string v2, "android.intent.action.VIEW"

    invoke-direct {v0, v2}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 108
    .local v0, "intent":Landroid/content/Intent;
    invoke-static {v1}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    invoke-virtual {v0, v2}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 109
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->getActivity()Landroid/app/Activity;

    move-result-object v2

    invoke-virtual {v2, v0}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V

    .line 110
    return-void
.end method

.method private getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 121
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/IGGUrlHelper;
    .locals 1

    .prologue
    .line 114
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->instance:Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    if-nez v0, :cond_0

    .line 115
    new-instance v0, Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->instance:Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    .line 117
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->instance:Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 17
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 18
    return-void
.end method

.method public FaceBookLike()V
    .locals 3

    .prologue
    .line 63
    const-string v0, "https://www.facebook.com/ClashofGangs"

    .line 64
    .local v0, "pUrl":Ljava/lang/String;
    invoke-direct {p0, v0}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->OpenUrl(Ljava/lang/String;)V

    .line 65
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->FacebookLikeCallBack:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 66
    return-void
.end method

.method public ForumLink()V
    .locals 2

    .prologue
    .line 79
    invoke-static {}, Lcom/igg/sdk/IGGURLBundle;->sharedInstance()Lcom/igg/sdk/IGGURLBundle;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGURLBundle;->forumURL()Ljava/lang/String;

    move-result-object v0

    .line 80
    .local v0, "pUrl":Ljava/lang/String;
    invoke-direct {p0, v0}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->OpenUrl(Ljava/lang/String;)V

    .line 81
    return-void
.end method

.method public GetFaceBookLike()Ljava/lang/String;
    .locals 1

    .prologue
    .line 25
    const-string v0, "https://www.facebook.com/ClashofGangs"

    .line 26
    .local v0, "pUrl":Ljava/lang/String;
    return-object v0
.end method

.method public GetForumLink()Ljava/lang/String;
    .locals 1

    .prologue
    .line 21
    invoke-static {}, Lcom/igg/sdk/IGGURLBundle;->sharedInstance()Lcom/igg/sdk/IGGURLBundle;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGURLBundle;->forumURL()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public GetPrivacyPolicy()Ljava/lang/String;
    .locals 1

    .prologue
    .line 50
    const-string v0, "http://www.igg.com/about/privacy_policy.php"

    .line 51
    .local v0, "pUrl":Ljava/lang/String;
    return-object v0
.end method

.method public GetSendTicket()Ljava/lang/String;
    .locals 2

    .prologue
    .line 40
    invoke-static {}, Lcom/igg/sdk/IGGURLBundle;->sharedInstance()Lcom/igg/sdk/IGGURLBundle;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGURLBundle;->serviceURL()Ljava/lang/String;

    move-result-object v0

    .line 41
    .local v0, "pUrl":Ljava/lang/String;
    return-object v0
.end method

.method public GetSupportLiveOnLogin()Ljava/lang/String;
    .locals 2

    .prologue
    .line 30
    invoke-static {}, Lcom/igg/sdk/IGGURLBundle;->sharedInstance()Lcom/igg/sdk/IGGURLBundle;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGURLBundle;->livechatURL()Ljava/lang/String;

    move-result-object v0

    .line 31
    .local v0, "pUrl":Ljava/lang/String;
    return-object v0
.end method

.method public GetSupportLiveOnShop()Ljava/lang/String;
    .locals 2

    .prologue
    .line 35
    invoke-static {}, Lcom/igg/sdk/IGGURLBundle;->sharedInstance()Lcom/igg/sdk/IGGURLBundle;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGURLBundle;->paymentLivechatURL()Ljava/lang/String;

    move-result-object v0

    .line 36
    .local v0, "pUrl":Ljava/lang/String;
    return-object v0
.end method

.method public GetTermsofService()Ljava/lang/String;
    .locals 1

    .prologue
    .line 45
    const-string v0, "http://www.igg.com/member/agreement.php"

    .line 46
    .local v0, "pUrl":Ljava/lang/String;
    return-object v0
.end method

.method public GetThirdPartPayment()Ljava/lang/String;
    .locals 6

    .prologue
    .line 55
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    .line 56
    .local v0, "pGameId":Ljava/lang/String;
    sget-object v3, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v3}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v1

    .line 57
    .local v1, "pSignedKey":Ljava/lang/String;
    const-string v3, "http://cog-snd.igg.com/shop.php?g_id=%s&signed_key=%s"

    const/4 v4, 0x2

    new-array v4, v4, [Ljava/lang/Object;

    const/4 v5, 0x0

    aput-object v0, v4, v5

    const/4 v5, 0x1

    aput-object v1, v4, v5

    invoke-static {v3, v4}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 58
    .local v2, "pUrl":Ljava/lang/String;
    return-object v2
.end method

.method public PrivacyPolicy()V
    .locals 1

    .prologue
    .line 94
    const-string v0, "http://www.igg.com/about/privacy_policy.php"

    .line 95
    .local v0, "pUrl":Ljava/lang/String;
    invoke-direct {p0, v0}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->OpenUrl(Ljava/lang/String;)V

    .line 96
    return-void
.end method

.method public SendTicket()V
    .locals 2

    .prologue
    .line 84
    invoke-static {}, Lcom/igg/sdk/IGGURLBundle;->sharedInstance()Lcom/igg/sdk/IGGURLBundle;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGURLBundle;->serviceURL()Ljava/lang/String;

    move-result-object v0

    .line 85
    .local v0, "pUrl":Ljava/lang/String;
    invoke-direct {p0, v0}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->OpenUrl(Ljava/lang/String;)V

    .line 86
    return-void
.end method

.method public SupportLiveOnLogin()V
    .locals 2

    .prologue
    .line 69
    invoke-static {}, Lcom/igg/sdk/IGGURLBundle;->sharedInstance()Lcom/igg/sdk/IGGURLBundle;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGURLBundle;->livechatURL()Ljava/lang/String;

    move-result-object v0

    .line 70
    .local v0, "pUrl":Ljava/lang/String;
    invoke-direct {p0, v0}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->OpenUrl(Ljava/lang/String;)V

    .line 71
    return-void
.end method

.method public SupportLiveOnShop()V
    .locals 2

    .prologue
    .line 74
    invoke-static {}, Lcom/igg/sdk/IGGURLBundle;->sharedInstance()Lcom/igg/sdk/IGGURLBundle;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGURLBundle;->paymentLivechatURL()Ljava/lang/String;

    move-result-object v0

    .line 75
    .local v0, "pUrl":Ljava/lang/String;
    invoke-direct {p0, v0}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->OpenUrl(Ljava/lang/String;)V

    .line 76
    return-void
.end method

.method public TermsofService()V
    .locals 1

    .prologue
    .line 89
    const-string v0, "http://www.igg.com/member/agreement.php"

    .line 90
    .local v0, "pUrl":Ljava/lang/String;
    invoke-direct {p0, v0}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->OpenUrl(Ljava/lang/String;)V

    .line 91
    return-void
.end method

.method public ThirdPartPayment()V
    .locals 6

    .prologue
    .line 99
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    .line 100
    .local v0, "pGameId":Ljava/lang/String;
    sget-object v3, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v3}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v1

    .line 101
    .local v1, "pSignedKey":Ljava/lang/String;
    const-string v3, "http://cog-snd.igg.com/shop.php?g_id=%s&signed_key=%s"

    const/4 v4, 0x2

    new-array v4, v4, [Ljava/lang/Object;

    const/4 v5, 0x0

    aput-object v0, v4, v5

    const/4 v5, 0x1

    aput-object v1, v4, v5

    invoke-static {v3, v4}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 102
    .local v2, "pUrl":Ljava/lang/String;
    invoke-direct {p0, v2}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->OpenUrl(Ljava/lang/String;)V

    .line 103
    return-void
.end method
