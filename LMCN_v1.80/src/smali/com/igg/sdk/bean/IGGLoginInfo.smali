.class public Lcom/igg/sdk/bean/IGGLoginInfo;
.super Ljava/lang/Object;
.source "IGGLoginInfo.java"


# instance fields
.field private accessKey:Ljava/lang/String;

.field private authCode:Ljava/lang/String;

.field private checkAllBindType:Ljava/lang/String;

.field private checkBindType:Ljava/lang/String;

.field private deviceType:Ljava/lang/String;

.field private flag:I

.field private gameId:Ljava/lang/String;

.field private googlePlusToken:Ljava/lang/String;

.field private guest:Ljava/lang/String;

.field private keepTime:I

.field private key:Ljava/lang/String;

.field private loginType:I

.field private m_Facebook_Token:Ljava/lang/String;

.field private name:Ljava/lang/String;

.field private pass:Ljava/lang/String;

.field private platformId:Ljava/lang/String;

.field private signedKey:Ljava/lang/String;

.field private thirdAccessKey:Ljava/lang/String;

.field private type:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 3
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 4
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->guest:Ljava/lang/String;

    .line 5
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->key:Ljava/lang/String;

    .line 6
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->deviceType:Ljava/lang/String;

    .line 7
    const v0, 0x278d00

    iput v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->keepTime:I

    .line 9
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->name:Ljava/lang/String;

    .line 10
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->pass:Ljava/lang/String;

    .line 11
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->gameId:Ljava/lang/String;

    .line 12
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->googlePlusToken:Ljava/lang/String;

    .line 13
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->m_Facebook_Token:Ljava/lang/String;

    .line 14
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->thirdAccessKey:Ljava/lang/String;

    .line 15
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->accessKey:Ljava/lang/String;

    .line 17
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->platformId:Ljava/lang/String;

    .line 18
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->type:Ljava/lang/String;

    .line 19
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->signedKey:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public getAccessKey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 139
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->accessKey:Ljava/lang/String;

    return-object v0
.end method

.method public getAuthCode()Ljava/lang/String;
    .locals 1

    .prologue
    .line 159
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->authCode:Ljava/lang/String;

    return-object v0
.end method

.method public getCheckAllBindType()Ljava/lang/String;
    .locals 1

    .prologue
    .line 175
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->checkAllBindType:Ljava/lang/String;

    return-object v0
.end method

.method public getCheckBindType()Ljava/lang/String;
    .locals 1

    .prologue
    .line 167
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->checkBindType:Ljava/lang/String;

    return-object v0
.end method

.method public getDeviceType()Ljava/lang/String;
    .locals 1

    .prologue
    .line 43
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->deviceType:Ljava/lang/String;

    return-object v0
.end method

.method public getFacebook_token()Ljava/lang/String;
    .locals 1

    .prologue
    .line 125
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->m_Facebook_Token:Ljava/lang/String;

    return-object v0
.end method

.method public getFlag()I
    .locals 1

    .prologue
    .line 151
    iget v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->flag:I

    return v0
.end method

.method public getGameId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 78
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->gameId:Ljava/lang/String;

    return-object v0
.end method

.method public getGooglePlusToken()Ljava/lang/String;
    .locals 1

    .prologue
    .line 118
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->googlePlusToken:Ljava/lang/String;

    return-object v0
.end method

.method public getGuest()Ljava/lang/String;
    .locals 1

    .prologue
    .line 27
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->guest:Ljava/lang/String;

    return-object v0
.end method

.method public getKeepTime()I
    .locals 1

    .prologue
    .line 54
    iget v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->keepTime:I

    return v0
.end method

.method public getKey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 35
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->key:Ljava/lang/String;

    return-object v0
.end method

.method public getLoginType()I
    .locals 1

    .prologue
    .line 102
    iget v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->loginType:I

    return v0
.end method

.method public getName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 62
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->name:Ljava/lang/String;

    return-object v0
.end method

.method public getPass()Ljava/lang/String;
    .locals 1

    .prologue
    .line 70
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->pass:Ljava/lang/String;

    return-object v0
.end method

.method public getPlatformId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 86
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->platformId:Ljava/lang/String;

    return-object v0
.end method

.method public getRd_access_key()Ljava/lang/String;
    .locals 1

    .prologue
    .line 131
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->thirdAccessKey:Ljava/lang/String;

    return-object v0
.end method

.method public getSignedKey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 110
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->signedKey:Ljava/lang/String;

    return-object v0
.end method

.method public getType()Ljava/lang/String;
    .locals 1

    .prologue
    .line 94
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->type:Ljava/lang/String;

    return-object v0
.end method

.method public setAccessKey(Ljava/lang/String;)V
    .locals 0
    .param p1, "accessKey"    # Ljava/lang/String;

    .prologue
    .line 143
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->accessKey:Ljava/lang/String;

    .line 144
    return-void
.end method

.method public setAuthCode(Ljava/lang/String;)V
    .locals 0
    .param p1, "authCode"    # Ljava/lang/String;

    .prologue
    .line 163
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->authCode:Ljava/lang/String;

    .line 164
    return-void
.end method

.method public setCheckAllBindType(Ljava/lang/String;)V
    .locals 0
    .param p1, "checkAllBindType"    # Ljava/lang/String;

    .prologue
    .line 179
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->checkAllBindType:Ljava/lang/String;

    .line 180
    return-void
.end method

.method public setCheckBindType(Ljava/lang/String;)V
    .locals 0
    .param p1, "checkBindType"    # Ljava/lang/String;

    .prologue
    .line 171
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->checkBindType:Ljava/lang/String;

    .line 172
    return-void
.end method

.method public setDeviceType(Ljava/lang/String;)V
    .locals 0
    .param p1, "deviceType"    # Ljava/lang/String;

    .prologue
    .line 47
    if-nez p1, :cond_0

    .line 48
    const-string p1, ""

    .line 50
    :cond_0
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->deviceType:Ljava/lang/String;

    .line 51
    return-void
.end method

.method public setFacebook_token(Ljava/lang/String;)V
    .locals 0
    .param p1, "facebook_token"    # Ljava/lang/String;

    .prologue
    .line 128
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->m_Facebook_Token:Ljava/lang/String;

    .line 129
    return-void
.end method

.method public setFlag(I)V
    .locals 0
    .param p1, "flag"    # I

    .prologue
    .line 155
    iput p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->flag:I

    .line 156
    return-void
.end method

.method public setGameId(Ljava/lang/String;)V
    .locals 0
    .param p1, "gameId"    # Ljava/lang/String;

    .prologue
    .line 82
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->gameId:Ljava/lang/String;

    .line 83
    return-void
.end method

.method public setGooglePlusToken(Ljava/lang/String;)V
    .locals 0
    .param p1, "googlePlusToken"    # Ljava/lang/String;

    .prologue
    .line 122
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->googlePlusToken:Ljava/lang/String;

    .line 123
    return-void
.end method

.method public setGuest(Ljava/lang/String;)V
    .locals 0
    .param p1, "guest"    # Ljava/lang/String;

    .prologue
    .line 31
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->guest:Ljava/lang/String;

    .line 32
    return-void
.end method

.method public setKeepTime(I)V
    .locals 0
    .param p1, "keepTime"    # I

    .prologue
    .line 58
    iput p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->keepTime:I

    .line 59
    return-void
.end method

.method public setKey(Ljava/lang/String;)V
    .locals 0
    .param p1, "key"    # Ljava/lang/String;

    .prologue
    .line 39
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->key:Ljava/lang/String;

    .line 40
    return-void
.end method

.method public setLoginType(Ljava/lang/Integer;)V
    .locals 1
    .param p1, "loginType"    # Ljava/lang/Integer;

    .prologue
    .line 106
    invoke-virtual {p1}, Ljava/lang/Integer;->intValue()I

    move-result v0

    iput v0, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->loginType:I

    .line 107
    return-void
.end method

.method public setLogintype(I)V
    .locals 0
    .param p1, "logintype"    # I

    .prologue
    .line 147
    iput p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->loginType:I

    .line 148
    return-void
.end method

.method public setName(Ljava/lang/String;)V
    .locals 0
    .param p1, "name"    # Ljava/lang/String;

    .prologue
    .line 66
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->name:Ljava/lang/String;

    .line 67
    return-void
.end method

.method public setPass(Ljava/lang/String;)V
    .locals 0
    .param p1, "pass"    # Ljava/lang/String;

    .prologue
    .line 74
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->pass:Ljava/lang/String;

    .line 75
    return-void
.end method

.method public setPlatformId(Ljava/lang/String;)V
    .locals 0
    .param p1, "platformId"    # Ljava/lang/String;

    .prologue
    .line 90
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->platformId:Ljava/lang/String;

    .line 91
    return-void
.end method

.method public setRd_access_key(Ljava/lang/String;)V
    .locals 0
    .param p1, "third_access_key"    # Ljava/lang/String;

    .prologue
    .line 135
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->thirdAccessKey:Ljava/lang/String;

    .line 136
    return-void
.end method

.method public setSignedKey(Ljava/lang/String;)V
    .locals 0
    .param p1, "signedKey"    # Ljava/lang/String;

    .prologue
    .line 114
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->signedKey:Ljava/lang/String;

    .line 115
    return-void
.end method

.method public setType(Ljava/lang/String;)V
    .locals 0
    .param p1, "type"    # Ljava/lang/String;

    .prologue
    .line 98
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGLoginInfo;->type:Ljava/lang/String;

    .line 99
    return-void
.end method
