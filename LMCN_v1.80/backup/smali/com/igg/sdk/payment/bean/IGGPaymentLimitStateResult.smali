.class public Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;
.super Ljava/lang/Object;
.source "IGGPaymentLimitStateResult.java"


# instance fields
.field private limit:Z

.field private limitation:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

.field private message:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getLimitation()Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;
    .locals 1

    .prologue
    .line 18
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->limitation:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    return-object v0
.end method

.method public getMessage()Ljava/lang/String;
    .locals 1

    .prologue
    .line 34
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->message:Ljava/lang/String;

    return-object v0
.end method

.method public isLimit()Z
    .locals 1

    .prologue
    .line 26
    iget-boolean v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->limit:Z

    return v0
.end method

.method public setLimit(Z)V
    .locals 0
    .param p1, "limit"    # Z

    .prologue
    .line 30
    iput-boolean p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->limit:Z

    .line 31
    return-void
.end method

.method public setLimitation(Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;)V
    .locals 0
    .param p1, "limitation"    # Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .prologue
    .line 22
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->limitation:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .line 23
    return-void
.end method

.method public setMessage(Ljava/lang/String;)V
    .locals 0
    .param p1, "message"    # Ljava/lang/String;

    .prologue
    .line 38
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->message:Ljava/lang/String;

    .line 39
    return-void
.end method
