.class Lcom/igg/sdk/account/IGGAccountLogin$1;
.super Ljava/lang/Object;
.source "IGGAccountLogin.java"

# interfaces
.implements Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountLogin;->login(Lcom/igg/sdk/account/LoginListener;Lcom/igg/sdk/account/LoginDelegate;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountLogin;

.field final synthetic val$listener:Lcom/igg/sdk/account/LoginListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountLogin;Lcom/igg/sdk/account/LoginListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountLogin;

    .prologue
    .line 163
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountLogin$1;->this$0:Lcom/igg/sdk/account/IGGAccountLogin;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountLogin$1;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onSessionExpired(ZZLcom/igg/sdk/account/IGGAccountSession;)V
    .locals 2
    .param p1, "localExpired"    # Z
    .param p2, "serverExpired"    # Z
    .param p3, "session"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    const/4 v1, 0x1

    .line 169
    if-eq p1, v1, :cond_0

    if-ne p2, v1, :cond_1

    .line 171
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$1;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-interface {v0, v1, p3}, Lcom/igg/sdk/account/LoginListener;->onLocalSessionExpired(ZLcom/igg/sdk/account/IGGAccountSession;)V

    .line 176
    :goto_0
    return-void

    .line 173
    :cond_1
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$1;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    invoke-interface {v0, v1, p3}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    .line 174
    invoke-static {}, Lcom/igg/sdk/IGGAppProfile;->sharedInstance()Lcom/igg/sdk/IGGAppProfile;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGAppProfile;->updateLastLoginTime()V

    goto :goto_0
.end method
