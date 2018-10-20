.class public final enum Lcom/igexin/push/extension/distribution/basic/i/d;
.super Ljava/lang/Enum;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igexin/push/extension/distribution/basic/i/d;",
        ">;"
    }
.end annotation


# static fields
.field public static final enum a:Lcom/igexin/push/extension/distribution/basic/i/d;

.field public static final enum b:Lcom/igexin/push/extension/distribution/basic/i/d;

.field private static final synthetic c:[Lcom/igexin/push/extension/distribution/basic/i/d;


# direct methods
.method static constructor <clinit>()V
    .locals 4

    const/4 v3, 0x1

    const/4 v2, 0x0

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d;

    const-string v1, "GET"

    invoke-direct {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/d;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/d;->a:Lcom/igexin/push/extension/distribution/basic/i/d;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d;

    const-string v1, "POST"

    invoke-direct {v0, v1, v3}, Lcom/igexin/push/extension/distribution/basic/i/d;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/d;->b:Lcom/igexin/push/extension/distribution/basic/i/d;

    const/4 v0, 0x2

    new-array v0, v0, [Lcom/igexin/push/extension/distribution/basic/i/d;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/d;->a:Lcom/igexin/push/extension/distribution/basic/i/d;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/d;->b:Lcom/igexin/push/extension/distribution/basic/i/d;

    aput-object v1, v0, v3

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/d;->c:[Lcom/igexin/push/extension/distribution/basic/i/d;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method
