.class public Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;
.super Ljava/lang/Object;
.source "IGGRealNameVerificationResult.java"


# instance fields
.field private isMinor:Z

.field private state:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 9
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getState()Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    .locals 1

    .prologue
    .line 14
    iget-object v0, p0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->state:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    return-object v0
.end method

.method public isMinor()Z
    .locals 1

    .prologue
    .line 22
    iget-boolean v0, p0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->isMinor:Z

    return v0
.end method

.method public setMinor(Z)V
    .locals 0
    .param p1, "minor"    # Z

    .prologue
    .line 26
    iput-boolean p1, p0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->isMinor:Z

    .line 27
    return-void
.end method

.method public setState(Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;)V
    .locals 0
    .param p1, "state"    # Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .prologue
    .line 18
    iput-object p1, p0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->state:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 19
    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .prologue
    .line 31
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-super {p0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "state:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->state:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ","

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "isMinor:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-boolean v2, p0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->isMinor:Z

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ")"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 34
    .local v0, "ret":Ljava/lang/String;
    return-object v0
.end method
