.class public Lcom/igg/sdk/payment/bean/IGGGameItem$Flag;
.super Ljava/lang/Object;
.source "IGGGameItem.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/payment/bean/IGGGameItem;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Flag"
.end annotation


# instance fields
.field public final DISCOUNTED:I

.field public final HOT:I

.field public final NEW:I

.field public final NORMAL:I


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 31
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 35
    const/4 v0, 0x1

    iput v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem$Flag;->NORMAL:I

    .line 40
    const/4 v0, 0x2

    iput v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem$Flag;->DISCOUNTED:I

    .line 45
    const/4 v0, 0x3

    iput v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem$Flag;->HOT:I

    .line 50
    const/4 v0, 0x4

    iput v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem$Flag;->NEW:I

    return-void
.end method
