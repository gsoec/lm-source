.class public Lcom/igg/sdk/service/MycardOrderInfoService;
.super Ljava/lang/Object;
.source "MycardOrderInfoService.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;,
        Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsListener;
    }
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 17
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getOrderNumber(Ljava/lang/String;IILcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;)V
    .locals 7
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "itemId"    # I
    .param p3, "amount"    # I
    .param p4, "listener"    # Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;

    .prologue
    .line 79
    const-string v4, ""

    const-string v5, ""

    move-object v0, p0

    move-object v1, p1

    move v2, p2

    move v3, p3

    move-object v6, p4

    invoke-virtual/range {v0 .. v6}, Lcom/igg/sdk/service/MycardOrderInfoService;->getOrderNumber(Ljava/lang/String;IILjava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;)V

    .line 80
    return-void
.end method

.method public getOrderNumber(Ljava/lang/String;IILjava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;)V
    .locals 7
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "itemId"    # I
    .param p3, "amount"    # I
    .param p4, "cha_id"    # Ljava/lang/String;
    .param p5, "server_id"    # Ljava/lang/String;
    .param p6, "listener"    # Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;

    .prologue
    .line 93
    new-instance v0, Lcom/igg/sdk/service/IGGPaymentService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGPaymentService;-><init>()V

    new-instance v6, Lcom/igg/sdk/service/MycardOrderInfoService$2;

    invoke-direct {v6, p0, p6}, Lcom/igg/sdk/service/MycardOrderInfoService$2;-><init>(Lcom/igg/sdk/service/MycardOrderInfoService;Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsOrdersSerialListener;)V

    move-object v1, p1

    move v2, p2

    move v3, p3

    move-object v4, p4

    move-object v5, p5

    invoke-virtual/range {v0 .. v6}, Lcom/igg/sdk/service/IGGPaymentService;->getOrdersSerialNumber(Ljava/lang/String;IILjava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;)V

    .line 104
    return-void
.end method

.method public loadItems(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsListener;)V
    .locals 2
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "channelName"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsListener;

    .prologue
    .line 43
    new-instance v0, Lcom/igg/sdk/service/IGGPaymentService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGPaymentService;-><init>()V

    new-instance v1, Lcom/igg/sdk/service/MycardOrderInfoService$1;

    invoke-direct {v1, p0, p3}, Lcom/igg/sdk/service/MycardOrderInfoService$1;-><init>(Lcom/igg/sdk/service/MycardOrderInfoService;Lcom/igg/sdk/service/MycardOrderInfoService$PaymentItemsListener;)V

    invoke-virtual {v0, p1, p2, v1}, Lcom/igg/sdk/service/IGGPaymentService;->loadItems(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;)V

    .line 68
    return-void
.end method
