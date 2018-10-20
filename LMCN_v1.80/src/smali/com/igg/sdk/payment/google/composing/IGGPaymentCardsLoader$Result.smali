.class public Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;
.super Ljava/lang/Object;
.source "IGGPaymentCardsLoader.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "Result"
.end annotation


# instance fields
.field private IGGGameItems:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;"
        }
    .end annotation
.end field

.field private purchaseLimit:I

.field final synthetic this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;


# direct methods
.method public constructor <init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;Ljava/util/ArrayList;I)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;
    .param p3, "purchaseLimit"    # I
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;I)V"
        }
    .end annotation

    .prologue
    .line 105
    .local p2, "IGGGameItems":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 106
    iput-object p2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->IGGGameItems:Ljava/util/ArrayList;

    .line 107
    iput p3, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->purchaseLimit:I

    .line 108
    return-void
.end method


# virtual methods
.method public getIGGGameItems()Ljava/util/ArrayList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/ArrayList",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;"
        }
    .end annotation

    .prologue
    .line 111
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->IGGGameItems:Ljava/util/ArrayList;

    return-object v0
.end method

.method public getPurchaseLimit()I
    .locals 1

    .prologue
    .line 119
    iget v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->purchaseLimit:I

    return v0
.end method

.method public setIGGGameItems(Ljava/util/ArrayList;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 115
    .local p1, "IGGGameItems":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->IGGGameItems:Ljava/util/ArrayList;

    .line 116
    return-void
.end method

.method public setPurchaseLimit(I)V
    .locals 0
    .param p1, "purchaseLimit"    # I

    .prologue
    .line 123
    iput p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->purchaseLimit:I

    .line 124
    return-void
.end method
