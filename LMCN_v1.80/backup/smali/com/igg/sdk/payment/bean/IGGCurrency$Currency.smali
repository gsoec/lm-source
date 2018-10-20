.class public final enum Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;
.super Ljava/lang/Enum;
.source "IGGCurrency.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/payment/bean/IGGCurrency;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "Currency"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum AED:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum AUD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum BRL:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum CAD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum COP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum EGP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum EUR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum GBP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum IDR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum INR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum JPY:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum KRW:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum MOP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum MXN:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum MYR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum PHP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum QAR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum RMB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum RUB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum SAR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum SGD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum THB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum TRY:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum TWD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum USD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field public static final enum VND:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;


# direct methods
.method static constructor <clinit>()V
    .locals 8

    .prologue
    const/4 v7, 0x4

    const/4 v6, 0x3

    const/4 v5, 0x2

    const/4 v4, 0x1

    const/4 v3, 0x0

    .line 24
    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "USD"

    invoke-direct {v0, v1, v3}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->USD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "RMB"

    invoke-direct {v0, v1, v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->RMB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "EUR"

    invoke-direct {v0, v1, v5}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->EUR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "TWD"

    invoke-direct {v0, v1, v6}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->TWD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "BRL"

    invoke-direct {v0, v1, v7}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->BRL:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    .line 25
    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "MXN"

    const/4 v2, 0x5

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->MXN:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "THB"

    const/4 v2, 0x6

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->THB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "RUB"

    const/4 v2, 0x7

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->RUB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "JPY"

    const/16 v2, 0x8

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->JPY:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "KRW"

    const/16 v2, 0x9

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->KRW:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    .line 26
    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "IDR"

    const/16 v2, 0xa

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->IDR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "VND"

    const/16 v2, 0xb

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->VND:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "AED"

    const/16 v2, 0xc

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->AED:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "QAR"

    const/16 v2, 0xd

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->QAR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "EGP"

    const/16 v2, 0xe

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->EGP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    .line 27
    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "INR"

    const/16 v2, 0xf

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->INR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "SGD"

    const/16 v2, 0x10

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->SGD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "CAD"

    const/16 v2, 0x11

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->CAD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "GBP"

    const/16 v2, 0x12

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->GBP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "AUD"

    const/16 v2, 0x13

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->AUD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    .line 28
    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "MOP"

    const/16 v2, 0x14

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->MOP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "PHP"

    const/16 v2, 0x15

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->PHP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "COP"

    const/16 v2, 0x16

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->COP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "MYR"

    const/16 v2, 0x17

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->MYR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    .line 29
    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "TRY"

    const/16 v2, 0x18

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->TRY:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    new-instance v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    const-string v1, "SAR"

    const/16 v2, 0x19

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->SAR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    .line 23
    const/16 v0, 0x1a

    new-array v0, v0, [Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    sget-object v1, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->USD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->RMB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v1, v0, v4

    sget-object v1, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->EUR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v1, v0, v5

    sget-object v1, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->TWD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v1, v0, v6

    sget-object v1, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->BRL:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v1, v0, v7

    const/4 v1, 0x5

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->MXN:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/4 v1, 0x6

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->THB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/4 v1, 0x7

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->RUB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x8

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->JPY:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x9

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->KRW:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0xa

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->IDR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0xb

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->VND:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0xc

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->AED:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0xd

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->QAR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0xe

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->EGP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0xf

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->INR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x10

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->SGD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x11

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->CAD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x12

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->GBP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x13

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->AUD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x14

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->MOP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x15

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->PHP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x16

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->COP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x17

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->MYR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x18

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->TRY:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    const/16 v1, 0x19

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->SAR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    aput-object v2, v0, v1

    sput-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->$VALUES:[Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .prologue
    .line 23
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 23
    const-class v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;
    .locals 1

    .prologue
    .line 23
    sget-object v0, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->$VALUES:[Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v0}, [Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    return-object v0
.end method
