.class Lcom/igexin/push/core/c/d;
.super Ljava/util/TimerTask;


# instance fields
.field final synthetic a:Lcom/igexin/push/core/c/c;


# direct methods
.method constructor <init>(Lcom/igexin/push/core/c/c;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/core/c/d;->a:Lcom/igexin/push/core/c/c;

    invoke-direct {p0}, Ljava/util/TimerTask;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 4

    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/core/c/d;->a:Lcom/igexin/push/core/c/c;

    invoke-static {v1}, Lcom/igexin/push/core/c/c;->a(Lcom/igexin/push/core/c/c;)Ljava/lang/String;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/core/c/d;->a:Lcom/igexin/push/core/c/c;

    invoke-static {v2}, Lcom/igexin/push/core/c/c;->b(Lcom/igexin/push/core/c/c;)Lcom/igexin/push/d/c/a;

    move-result-object v2

    iget-object v3, p0, Lcom/igexin/push/core/c/d;->a:Lcom/igexin/push/core/c/c;

    invoke-static {v3}, Lcom/igexin/push/core/c/c;->c(Lcom/igexin/push/core/c/c;)Lcom/igexin/push/core/bean/PushTaskBean;

    move-result-object v3

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/push/core/a/e;->a(Ljava/lang/String;Lcom/igexin/push/d/c/a;Lcom/igexin/push/core/bean/PushTaskBean;)V

    iget-object v0, p0, Lcom/igexin/push/core/c/d;->a:Lcom/igexin/push/core/c/c;

    invoke-static {v0}, Lcom/igexin/push/core/c/c;->b(Lcom/igexin/push/core/c/c;)Lcom/igexin/push/d/c/a;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/core/c/d;->a:Lcom/igexin/push/core/c/c;

    invoke-static {v1}, Lcom/igexin/push/core/c/c;->b(Lcom/igexin/push/core/c/c;)Lcom/igexin/push/d/c/a;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/d/c/a;->a()I

    move-result v1

    add-int/lit8 v1, v1, 0x1

    invoke-virtual {v0, v1}, Lcom/igexin/push/d/c/a;->a(I)V

    return-void
.end method
