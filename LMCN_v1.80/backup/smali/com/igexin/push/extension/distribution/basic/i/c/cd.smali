.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/cd;
.super Lcom/igexin/push/extension/distribution/basic/i/c/ar;


# direct methods
.method constructor <init>(Ljava/lang/String;I)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ar;-><init>(Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/i/c/as;)V

    return-void
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/aq;Lcom/igexin/push/extension/distribution/basic/i/c/a;)V
    .locals 3

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->e()V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ai;-><init>()V

    iget-object v1, v0, Lcom/igexin/push/extension/distribution/basic/i/c/ai;->b:Ljava/lang/StringBuilder;

    const/16 v2, 0x3e

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->a(C)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cd;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    return-void
.end method
