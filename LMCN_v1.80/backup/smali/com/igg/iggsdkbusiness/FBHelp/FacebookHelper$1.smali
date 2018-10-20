.class Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;
.super Ljava/lang/Object;
.source "FacebookHelper.java"

# interfaces
.implements Lcom/facebook/FacebookCallback;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->RegisterCallback()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/facebook/FacebookCallback",
        "<",
        "Lcom/facebook/login/LoginResult;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    .prologue
    .line 245
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCancel()V
    .locals 2

    .prologue
    .line 277
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    const-string v1, "onCancel"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 278
    return-void
.end method

.method public onError(Lcom/facebook/FacebookException;)V
    .locals 3
    .param p1, "exception"    # Lcom/facebook/FacebookException;

    .prologue
    .line 281
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "exception = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p1}, Lcom/facebook/FacebookException;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 282
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;->Switch:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_FBCallbackType:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    if-ne v0, v1, :cond_1

    .line 283
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookLoginFailedCallBack:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 287
    :cond_0
    :goto_0
    return-void

    .line 284
    :cond_1
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;->Bind:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_FBCallbackType:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    if-ne v0, v1, :cond_0

    .line 285
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookBindFailedCallBack:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method

.method public onSuccess(Lcom/facebook/login/LoginResult;)V
    .locals 7
    .param p1, "loginResult"    # Lcom/facebook/login/LoginResult;

    .prologue
    .line 248
    invoke-virtual {p1}, Lcom/facebook/login/LoginResult;->getAccessToken()Lcom/facebook/AccessToken;

    move-result-object v0

    .line 249
    .local v0, "accessToken":Lcom/facebook/AccessToken;
    invoke-virtual {v0}, Lcom/facebook/AccessToken;->getToken()Ljava/lang/String;

    move-result-object v3

    .line 250
    .local v3, "token":Ljava/lang/String;
    invoke-virtual {v0}, Lcom/facebook/AccessToken;->getUserId()Ljava/lang/String;

    move-result-object v4

    .line 251
    .local v4, "userId":Ljava/lang/String;
    invoke-virtual {p1}, Lcom/facebook/login/LoginResult;->getAccessToken()Lcom/facebook/AccessToken;

    move-result-object v5

    new-instance v6, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;

    invoke-direct {v6, p0, v4, v3}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;-><init>(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;Ljava/lang/String;Ljava/lang/String;)V

    invoke-static {v5, v6}, Lcom/facebook/GraphRequest;->newMeRequest(Lcom/facebook/AccessToken;Lcom/facebook/GraphRequest$GraphJSONObjectCallback;)Lcom/facebook/GraphRequest;

    move-result-object v2

    .line 270
    .local v2, "request":Lcom/facebook/GraphRequest;
    new-instance v1, Landroid/os/Bundle;

    invoke-direct {v1}, Landroid/os/Bundle;-><init>()V

    .line 271
    .local v1, "parameters":Landroid/os/Bundle;
    const-string v5, "fields"

    const-string v6, "id,name,email"

    invoke-virtual {v1, v5, v6}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 272
    invoke-virtual {v2, v1}, Lcom/facebook/GraphRequest;->setParameters(Landroid/os/Bundle;)V

    .line 273
    invoke-virtual {v2}, Lcom/facebook/GraphRequest;->executeAsync()Lcom/facebook/GraphRequestAsyncTask;

    .line 274
    return-void
.end method

.method public bridge synthetic onSuccess(Ljava/lang/Object;)V
    .locals 0

    .prologue
    .line 245
    check-cast p1, Lcom/facebook/login/LoginResult;

    invoke-virtual {p0, p1}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->onSuccess(Lcom/facebook/login/LoginResult;)V

    return-void
.end method
