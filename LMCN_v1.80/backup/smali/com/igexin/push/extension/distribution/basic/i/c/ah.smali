.class Lcom/igexin/push/extension/distribution/basic/i/c/ah;
.super Lcom/igexin/push/extension/distribution/basic/i/c/af;


# instance fields
.field private final b:Ljava/lang/String;


# direct methods
.method constructor <init>(Ljava/lang/String;)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/af;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ag;)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->e:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ah;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ah;->b:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method m()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ah;->b:Ljava/lang/String;

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ah;->m()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
