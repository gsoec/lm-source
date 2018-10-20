.class public Lcom/igg/sdk/realname/IGGRealNameVerification;
.super Ljava/lang/Object;
.source "IGGRealNameVerification.java"


# static fields
.field private static final TAG:Ljava/lang/String; = "RealNameVerification"


# instance fields
.field private proxy:Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 33
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 34
    new-instance v0, Lcom/igg/sdk/realname/IGGRealNameVerificationDefaultCompatProxy;

    invoke-direct {v0}, Lcom/igg/sdk/realname/IGGRealNameVerificationDefaultCompatProxy;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/realname/IGGRealNameVerification;->proxy:Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;

    .line 35
    return-void
.end method


# virtual methods
.method public requestState(Lcom/igg/sdk/realname/IGGVerificationStateListener;)V
    .locals 4
    .param p1, "listener"    # Lcom/igg/sdk/realname/IGGVerificationStateListener;

    .prologue
    .line 46
    new-instance v0, Lcom/igg/sdk/service/IGGRealNameVerificationService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGRealNameVerificationService;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/realname/IGGRealNameVerification;->proxy:Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;

    invoke-interface {v1}, Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;->getAccessKey()Ljava/lang/String;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/realname/IGGRealNameVerification;->proxy:Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;

    invoke-interface {v2}, Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;->getIGGId()Ljava/lang/String;

    move-result-object v2

    iget-object v3, p0, Lcom/igg/sdk/realname/IGGRealNameVerification;->proxy:Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;

    invoke-interface {v3}, Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v0, v1, v2, v3, p1}, Lcom/igg/sdk/service/IGGRealNameVerificationService;->requestState(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/realname/IGGVerificationStateListener;)V

    .line 47
    return-void
.end method

.method public setRealNameVerificationCompatProxy(Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;)V
    .locals 0
    .param p1, "proxy"    # Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;

    .prologue
    .line 38
    iput-object p1, p0, Lcom/igg/sdk/realname/IGGRealNameVerification;->proxy:Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;

    .line 39
    return-void
.end method
