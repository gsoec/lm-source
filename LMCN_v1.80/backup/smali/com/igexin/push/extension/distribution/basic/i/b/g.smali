.class public final enum Lcom/igexin/push/extension/distribution/basic/i/b/g;
.super Ljava/lang/Enum;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igexin/push/extension/distribution/basic/i/b/g;",
        ">;"
    }
.end annotation


# static fields
.field public static final enum a:Lcom/igexin/push/extension/distribution/basic/i/b/g;

.field public static final enum b:Lcom/igexin/push/extension/distribution/basic/i/b/g;

.field public static final enum c:Lcom/igexin/push/extension/distribution/basic/i/b/g;

.field private static final synthetic d:[Lcom/igexin/push/extension/distribution/basic/i/b/g;


# direct methods
.method static constructor <clinit>()V
    .locals 5

    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/g;

    const-string v1, "noQuirks"

    invoke-direct {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/g;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/g;->a:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/g;

    const-string v1, "quirks"

    invoke-direct {v0, v1, v3}, Lcom/igexin/push/extension/distribution/basic/i/b/g;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/g;->b:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/g;

    const-string v1, "limitedQuirks"

    invoke-direct {v0, v1, v4}, Lcom/igexin/push/extension/distribution/basic/i/b/g;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/g;->c:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    const/4 v0, 0x3

    new-array v0, v0, [Lcom/igexin/push/extension/distribution/basic/i/b/g;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/b/g;->a:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/b/g;->b:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/b/g;->c:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    aput-object v1, v0, v4

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/g;->d:[Lcom/igexin/push/extension/distribution/basic/i/b/g;

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
