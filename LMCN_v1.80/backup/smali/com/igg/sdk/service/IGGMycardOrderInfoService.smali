.class public Lcom/igg/sdk/service/IGGMycardOrderInfoService;
.super Ljava/lang/Object;
.source "IGGMycardOrderInfoService.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;,
        Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;
    }
.end annotation


# instance fields
.field private paymentService:Lcom/igg/sdk/service/IGGPaymentService;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 17
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getOrderNumber(Ljava/lang/String;IILcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;)V
    .locals 7
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "itemId"    # I
    .param p3, "amount"    # I
    .param p4, "listener"    # Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;

    .prologue
    .line 82
    const-string v4, ""

    const-string v5, ""

    move-object v0, p0

    move-object v1, p1

    move v2, p2

    move v3, p3

    move-object v6, p4

    invoke-virtual/range {v0 .. v6}, Lcom/igg/sdk/service/IGGMycardOrderInfoService;->getOrderNumber(Ljava/lang/String;IILjava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;)V

    .line 83
    return-void
.end method

.method public getOrderNumber(Ljava/lang/String;IILjava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;)V
    .locals 7
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "itemId"    # I
    .param p3, "amount"    # I
    .param p4, "chaId"    # Ljava/lang/String;
    .param p5, "serverId"    # Ljava/lang/String;
    .param p6, "listener"    # Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;

    .prologue
    .line 96
    iget-object v0, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService;->paymentService:Lcom/igg/sdk/service/IGGPaymentService;

    new-instance v6, Lcom/igg/sdk/service/IGGMycardOrderInfoService$2;

    invoke-direct {v6, p0, p6}, Lcom/igg/sdk/service/IGGMycardOrderInfoService$2;-><init>(Lcom/igg/sdk/service/IGGMycardOrderInfoService;Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsOrdersSerialListener;)V

    move-object v1, p1

    move v2, p2

    move v3, p3

    move-object v4, p4

    move-object v5, p5

    invoke-virtual/range {v0 .. v6}, Lcom/igg/sdk/service/IGGPaymentService;->getOrdersSerialNumber(Ljava/lang/String;IILjava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;)V

    .line 107
    return-void
.end method

.method public loadItems(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;)V
    .locals 2
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "channelName"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;

    .prologue
    .line 45
    new-instance v0, Lcom/igg/sdk/service/IGGPaymentService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGPaymentService;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService;->paymentService:Lcom/igg/sdk/service/IGGPaymentService;

    .line 46
    iget-object v0, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService;->paymentService:Lcom/igg/sdk/service/IGGPaymentService;

    new-instance v1, Lcom/igg/sdk/service/IGGMycardOrderInfoService$1;

    invoke-direct {v1, p0, p3}, Lcom/igg/sdk/service/IGGMycardOrderInfoService$1;-><init>(Lcom/igg/sdk/service/IGGMycardOrderInfoService;Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;)V

    invoke-virtual {v0, p1, p2, v1}, Lcom/igg/sdk/service/IGGPaymentService;->loadItems(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;)V

    .line 71
    return-void
.end method
