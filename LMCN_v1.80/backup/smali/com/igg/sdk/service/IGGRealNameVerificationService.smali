.class public Lcom/igg/sdk/service/IGGRealNameVerificationService;
.super Ljava/lang/Object;
.source "IGGRealNameVerificationService.java"


# static fields
.field private static final TAG:Ljava/lang/String; = "RealNameVerificationService"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 26
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public requestState(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/realname/IGGVerificationStateListener;)V
    .locals 5
    .param p1, "signedKey"    # Ljava/lang/String;
    .param p2, "mID"    # Ljava/lang/String;
    .param p3, "gID"    # Ljava/lang/String;
    .param p4, "listener"    # Lcom/igg/sdk/realname/IGGVerificationStateListener;

    .prologue
    .line 30
    new-instance v0, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getRealNameVerificationURL()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "?signed_key="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&m_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&g_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&action=state"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    const/4 v2, 0x0

    const/16 v3, 0x2710

    new-instance v4, Lcom/igg/sdk/service/IGGRealNameVerificationService$1;

    invoke-direct {v4, p0, p4}, Lcom/igg/sdk/service/IGGRealNameVerificationService$1;-><init>(Lcom/igg/sdk/service/IGGRealNameVerificationService;Lcom/igg/sdk/realname/IGGVerificationStateListener;)V

    invoke-virtual {v0, v1, v2, v3, v4}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeadersRequestListener;)Lcom/igg/util/AsyncTask;

    .line 93
    return-void
.end method
