.class public Lcom/igg/sdk/payment/bean/IGGGameItem$Type;
.super Ljava/lang/Object;
.source "IGGGameItem.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/payment/bean/IGGGameItem;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Type"
.end annotation


# instance fields
.field public final CASH:I

.field public final COIN:I


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 21
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 22
    const/4 v0, 0x1

    iput v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem$Type;->CASH:I

    .line 23
    const/4 v0, 0x2

    iput v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem$Type;->COIN:I

    return-void
.end method
