.class Lcom/igexin/push/extension/distribution/basic/k/c;
.super Ljava/lang/Object;

# interfaces
.implements Landroid/content/DialogInterface$OnClickListener;


# instance fields
.field final synthetic a:Lcom/igexin/push/extension/distribution/basic/k/b;


# direct methods
.method constructor <init>(Lcom/igexin/push/extension/distribution/basic/k/b;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/k/c;->a:Lcom/igexin/push/extension/distribution/basic/k/b;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/content/DialogInterface;I)V
    .locals 5

    const/4 v4, 0x0

    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/c;->a:Lcom/igexin/push/extension/distribution/basic/k/b;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/k/b;->a(Lcom/igexin/push/extension/distribution/basic/k/b;)Ljava/lang/String;

    move-result-object v2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/c;->a:Lcom/igexin/push/extension/distribution/basic/k/b;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/k/b;->b(Lcom/igexin/push/extension/distribution/basic/k/b;)Ljava/lang/String;

    move-result-object v3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/c;->a:Lcom/igexin/push/extension/distribution/basic/k/b;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/k/b;->c(Lcom/igexin/push/extension/distribution/basic/k/b;)Lcom/igexin/push/extension/distribution/basic/b/n;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/b/n;->c()Ljava/util/List;

    move-result-object v0

    invoke-interface {v0, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/b/f;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/b/f;->b()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v2, v3, v0}, Lcom/igexin/push/core/a/e;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Z

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/c;->a:Lcom/igexin/push/extension/distribution/basic/k/b;

    invoke-static {v0, v4}, Lcom/igexin/push/extension/distribution/basic/k/b;->a(Lcom/igexin/push/extension/distribution/basic/k/b;Z)Z

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/k/c;->a:Lcom/igexin/push/extension/distribution/basic/k/b;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/k/b;->d(Lcom/igexin/push/extension/distribution/basic/k/b;)Landroid/app/Activity;

    move-result-object v0

    invoke-virtual {v0}, Landroid/app/Activity;->finish()V

    return-void
.end method
