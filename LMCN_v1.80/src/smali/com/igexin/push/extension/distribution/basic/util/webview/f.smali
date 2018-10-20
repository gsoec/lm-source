.class public final enum Lcom/igexin/push/extension/distribution/basic/util/webview/f;
.super Ljava/lang/Enum;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igexin/push/extension/distribution/basic/util/webview/f;",
        ">;"
    }
.end annotation


# static fields
.field public static final enum a:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

.field public static final enum b:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

.field public static final enum c:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

.field public static final enum d:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

.field private static final synthetic e:[Lcom/igexin/push/extension/distribution/basic/util/webview/f;


# direct methods
.method static constructor <clinit>()V
    .locals 6

    const/4 v5, 0x3

    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    const-string v1, "OK"

    invoke-direct {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/util/webview/f;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->a:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    const-string v1, "ERROR_HTTP"

    invoke-direct {v0, v1, v3}, Lcom/igexin/push/extension/distribution/basic/util/webview/f;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->b:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    const-string v1, "ERROR_FILE"

    invoke-direct {v0, v1, v4}, Lcom/igexin/push/extension/distribution/basic/util/webview/f;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->c:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    const-string v1, "OK_SOME_RES_FAILED"

    invoke-direct {v0, v1, v5}, Lcom/igexin/push/extension/distribution/basic/util/webview/f;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->d:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    const/4 v0, 0x4

    new-array v0, v0, [Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->a:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    aput-object v1, v0, v2

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->b:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->c:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    aput-object v1, v0, v4

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->d:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    aput-object v1, v0, v5

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->e:[Lcom/igexin/push/extension/distribution/basic/util/webview/f;

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
